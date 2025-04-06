namespace FileUploaderSample.Domains.Entities
{
    public class FileMetaData
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
