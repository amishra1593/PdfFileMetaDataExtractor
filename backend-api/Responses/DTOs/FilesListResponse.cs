namespace FileUploaderSample.Responses.DTOs
{
    public class FilesListResponse : BaseResponse
    {
        public List<FileMetadataDTO> metadataLists { get; set; }
    }
}
