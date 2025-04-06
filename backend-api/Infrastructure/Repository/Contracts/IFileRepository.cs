using FileUploaderSample.Domains.Entities;
using FileUploaderSample.Responses.DTOs;

namespace FileUploaderSample.Infrastructure.Repository.Contracts
{
    public interface IFileRepository
    {
        Task SaveFileToDatabase(FileMetaData file);
        Task<List<FileMetaData>> GetAllAsync(string? search);
    }
}
