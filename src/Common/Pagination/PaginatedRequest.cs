namespace CrunchyAppBackend.Common.Pagination
{
    public class PaginatedRequest
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}