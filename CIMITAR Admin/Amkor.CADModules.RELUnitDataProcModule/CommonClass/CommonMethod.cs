using System;
using Telerik.WinControls.UI;

namespace Amkor.CADModules.RELUnitDataProcModule.CommonClass
{
	// Token: 0x02000019 RID: 25
	public class CommonMethod
	{
		// Token: 0x06000101 RID: 257 RVA: 0x00010378 File Offset: 0x0000E578
		public GridViewDataColumn SetGridViewColumn(string fieldName, string headerText, bool isVisible, int width, bool isReadOnly, bool isFiltering = true, bool isWidthFix = false, string style = "TextBox")
		{
			GridViewDataColumn gridViewDataColumn = null;
			if (!(style == "TextBox"))
			{
				if (!(style == "Decimal"))
				{
					if (!(style == "CheckBox"))
					{
						if (style == "ComboBox")
						{
							gridViewDataColumn = new GridViewComboBoxColumn();
						}
					}
					else
					{
						gridViewDataColumn = new GridViewCheckBoxColumn();
						GridViewCheckBoxColumn gridViewCheckBoxColumn = gridViewDataColumn as GridViewCheckBoxColumn;
						gridViewCheckBoxColumn.EnableHeaderCheckBox = true;
						gridViewCheckBoxColumn.AllowSort = false;
						gridViewCheckBoxColumn.DataType = typeof(bool);
					}
				}
				else
				{
					gridViewDataColumn = new GridViewDecimalColumn();
				}
			}
			else
			{
				gridViewDataColumn = new GridViewTextBoxColumn();
			}
			if (isWidthFix)
			{
				gridViewDataColumn.MinWidth = width;
				gridViewDataColumn.MaxWidth = width;
			}
			gridViewDataColumn.AllowFiltering = isFiltering;
			gridViewDataColumn.FieldName = fieldName;
			gridViewDataColumn.HeaderText = headerText;
			gridViewDataColumn.IsVisible = isVisible;
			gridViewDataColumn.Width = width;
			gridViewDataColumn.ReadOnly = isReadOnly;
			return gridViewDataColumn;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00010464 File Offset: 0x0000E664
		public void GridViewSetDataSource(RadGridView grd, object obj)
		{
			grd.DataSource = obj;
			grd.TableElement.RowHeaderColumnWidth = ((grd.Rows.Count.ToString().Length == 1) ? 40 : (grd.Rows.Count.ToString().Length * 10 + 20));
		}
	}
}
