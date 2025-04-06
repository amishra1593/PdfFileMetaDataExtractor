using FileUploaderSample.Requests;
using FileUploaderSample.Responses.DTOs;

namespace FileUploaderSample.Services.Contracts
{
    public interface IFileService
    {
        Task<FileMetadataUploadResponse> SaveFileToDatabase(IFormFile file);

        Task<FilesListResponse> GetAllFilesAsync(FileListRequest request);
    }
}
