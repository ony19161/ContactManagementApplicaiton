export interface Pagination {
    pageIndex: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
