namespace FileUploaderSample.Requests
{
    public abstract class PaginationFilterRequest
    {
        public int? Page { get; set; } =    default(int?);
        public int? PageSize { get; set; } = default(int?);
    }
}
