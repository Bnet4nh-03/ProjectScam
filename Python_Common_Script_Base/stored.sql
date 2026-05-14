CREATE OR ALTER PROCEDURE sp_dynamic_update
    @p_payload NVARCHAR(MAX)   -- nhận ARRAY of payloads
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- =========================================================
    -- Input: JSON array
    -- [
    --   {
    --     "database": "TestDB",
    --     "table":    "Hw_Board",
    --     "keys": { "barcode": "ABB1D-0050" },
    --     "data": { "boardno": "SPD-103441", "boardserial": "#3602192", ... }
    --   },
    --   { ... },
    --   ...
    -- ]
    -- Tất cả rows trong cùng 1 lần gọi SP.
    -- =========================================================

    -- ── Validate: phải là JSON array ──────────────────────────
    IF ISJSON(@p_payload) = 0
    BEGIN
        RAISERROR('Payload is not valid JSON.', 16, 1);
        RETURN;
    END

    IF LEFT(LTRIM(@p_payload), 1) <> '['
    BEGIN
        RAISERROR('Payload must be a JSON array [...].', 16, 1);
        RETURN;
    END

    -- ── Work table: giải nén từng row từ array ────────────────
    CREATE TABLE #rows (
        row_idx      INT,
        database_name NVARCHAR(128),
        table_name   NVARCHAR(128),
        keys_json    NVARCHAR(MAX),
        data_json    NVARCHAR(MAX)
    );

    INSERT INTO #rows (row_idx, database_name, table_name, keys_json, data_json)
    SELECT
        CAST([key] AS INT)                        AS row_idx,
        JSON_VALUE([value], '$.database')         AS database_name,
        JSON_VALUE([value], '$.table')            AS table_name,
        JSON_QUERY([value], '$.keys')             AS keys_json,
        JSON_QUERY([value], '$.data')             AS data_json
    FROM OPENJSON(@p_payload);   -- iterate array

    -- Bỏ qua rows không có data (không có ô màu)
    DELETE FROM #rows WHERE data_json IS NULL OR data_json = '{}';

    IF NOT EXISTS (SELECT 1 FROM #rows)
    BEGIN
        DROP TABLE #rows;
        RETURN;   -- không có gì để update
    END

    -- ── Validate database & table (1 lần cho mỗi combo) ──────
    DECLARE @db   NVARCHAR(128),
            @tbl  NVARCHAR(128),
            @chk  NVARCHAR(MAX),
            @ok   INT;

    DECLARE cur_validate CURSOR LOCAL FAST_FORWARD FOR
        SELECT DISTINCT database_name, table_name FROM #rows;

    OPEN cur_validate;
    FETCH NEXT FROM cur_validate INTO @db, @tbl;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Validate DB
        IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = @db)
        BEGIN
            RAISERROR('Database "%s" not found.', 16, 1, @db);
            CLOSE cur_validate; DEALLOCATE cur_validate;
            DROP TABLE #rows; RETURN;
        END

        -- Validate Table trong DB đó
        SET @ok  = 0;
        SET @chk = N'SELECT @ok = COUNT(1) FROM '
                 + QUOTENAME(@db)
                 + N'.sys.tables t JOIN '
                 + QUOTENAME(@db)
                 + N'.sys.schemas s ON t.schema_id = s.schema_id '
                 + N'WHERE t.name = @tbl AND s.name = ''dbo''';

        EXEC sp_executesql @chk,
            N'@tbl NVARCHAR(128), @ok INT OUTPUT',
            @tbl = @tbl, @ok = @ok OUTPUT;

        IF @ok = 0
        BEGIN
            RAISERROR('Table "%s" not found in database "%s".', 16, 1, @tbl, @db);
            CLOSE cur_validate; DEALLOCATE cur_validate;
            DROP TABLE #rows; RETURN;
        END

        FETCH NEXT FROM cur_validate INTO @db, @tbl;
    END

    CLOSE cur_validate;
    DEALLOCATE cur_validate;

    -- ── Build & execute UPDATE cho từng row ───────────────────
    DECLARE
        @row_idx      INT,
        @full_ref     NVARCHAR(300),
        @keys_json    NVARCHAR(MAX),
        @data_json    NVARCHAR(MAX),
        @set_clause   NVARCHAR(MAX),
        @where_clause NVARCHAR(MAX),
        @sql          NVARCHAR(MAX);

    DECLARE cur_rows CURSOR LOCAL FAST_FORWARD FOR
        SELECT row_idx, database_name, table_name, keys_json, data_json
        FROM #rows
        ORDER BY row_idx;

    OPEN cur_rows;
    FETCH NEXT FROM cur_rows INTO @row_idx, @db, @tbl, @keys_json, @data_json;

    BEGIN TRANSACTION;

    BEGIN TRY
        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @full_ref = QUOTENAME(@db) + N'.dbo.' + QUOTENAME(@tbl);

            -- WHERE clause từ keys
            SELECT @where_clause = STRING_AGG(
                QUOTENAME([key]) + N' = N''' + REPLACE([value], N'''', N'''''') + N'''',
                N' AND '
            )
            FROM OPENJSON(@keys_json);

            -- SET clause từ data
            SELECT @set_clause = STRING_AGG(
                QUOTENAME([key]) + N' = N''' + REPLACE([value], N'''', N'''''') + N'''',
                N', '
            )
            FROM OPENJSON(@data_json);

            IF @where_clause IS NOT NULL AND @set_clause IS NOT NULL
            BEGIN
                SET @sql = N'UPDATE ' + @full_ref
                         + N' SET '   + @set_clause
                         + N' WHERE ' + @where_clause;

                EXEC sp_executesql @sql;
            END

            FETCH NEXT FROM cur_rows INTO @row_idx, @db, @tbl, @keys_json, @data_json;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        CLOSE cur_rows; DEALLOCATE cur_rows;
        DROP TABLE #rows;
        THROW;   -- re-raise lỗi về cho caller
    END CATCH;

    CLOSE cur_rows;
    DEALLOCATE cur_rows;
    DROP TABLE #rows;

END;
GO