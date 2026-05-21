export class Request {
    request_id: number | null = null;
    scode_id: number | null = null;
    location_id: number | null = null;
    request_type_id: number | null = null;
    is_urgent: number = 0; // 0 hoặc 1
    purpose: string = "";
    comment: string = "";
    hcc_comment: string | null = null;
    need_datetime: string | null = null;
    return_plan: string | null = null;
    status_type_id: number = 0;
    status_sub_type_id: number = 0;
    req_by_badge: string | null = null;
    hcc_by_badge: string | null = null;
    sub_scode_id: number | null = null;

    constructor(data?: Partial<Request>) {
        if (data) {
            Object.assign(this, data);
        }
    }

    // Plain Object
    toJSON() {
        return { ...this };
    }
}
