using AutoMapper;
using FileUploaderSample.Domains.Entities;
using FileUploaderSample.Infrastructure.EFConfig;
using FileUploaderSample.Infrastructure.Repository.Contracts;
using FileUploaderSample.Requests;
using FileUploaderSample.Responses.DTOs;
using FileUploaderSample.Services.Contracts;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FileUploaderSample.Services.Implemenation
{
    public class FileService : IFileService
    {

        public readonly IFileRepository _fileRepository;
        public readonly IValidationService _validationService;
        public readonly IMapper _mapper;
        public FileService(IFileRepository fileRepository, IValidationService validationService, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _validationService = validationService;
            _mapper = mapper;
        }


        public async Task<FileMetadataUploadResponse> SaveFileToDatabase(IFormFile file)
        {
            if(!_validationService.ValidateFileExtention(file))
                throw new Exception("Please upload a valid PDF file.");


            try
            {
                using var stream = file.OpenReadStream();
                var metadataDto = await ExtractMetadataAsync(stream, file.FileName);

                var fileEntity = new FileMetaData
                {
                    FileName = metadataDto.FileName,
                    Title = metadataDto.Title,
                    Author = metadataDto.Author,
                    PageCount = metadataDto.PageCount,
                    CreationDate = metadataDto.CreationDate
                };

                await _fileRepository.SaveFileToDatabase(fileEntity);

                return new FileMetadataUploadResponse
                {
                    FileMetaData = metadataDto
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save file contents}", ex);
            }

        }

        private async Task<FileMetadataDTO> ExtractMetadataAsync(Stream fileStream, string fileName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using var reader = new PdfReader(fileStream);
                    var info = reader.Info;

                    var metadata = new FileMetadataDTO
                    {
                        FileName = fileName,
                        Title = info.ContainsKey("Title") ? info["Title"] : "",
                        Author = info.ContainsKey("Author") ? info["Author"] : "",
                        PageCount = reader.NumberOfPages,
                        CreationDate = ParseCreationDate(info)
                    };
                    return metadata;
                }
                catch (Exception ex)
                {  
                    //Here we can throw our custome Exception by creating a Custome Error Class
                    throw new Exception("Failed to Extract data from file}", ex);
                }


            });
        }


        private DateTime ParseCreationDate(Dictionary<string, string> info)
        {
            if (info.ContainsKey("CreationDate") && info["CreationDate"].StartsWith("D:"))
            {
                var dateStr = info["CreationDate"].Substring(2); // strip "D:"
                if (DateTime.TryParseExact(dateStr.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                {
                    return parsedDate;
                }
            }
            return DateTime.UtcNow;
        }

        public async Task<FilesListResponse> GetAllFilesAsync(FileListRequest request)
        {
            try
            {
                var metaDataFileList = await _fileRepository.GetAllAsync(request?.searchValue);
                return new FilesListResponse
                {
                    metadataLists = _mapper.Map<List<FileMetadataDTO>>(metaDataFileList)
                };
            }
            catch (Exception ex)
            {
                //Here we can throw our custome Exception by creating a Custome Error Class
                throw new Exception("Failed to fetch data from database}", ex);
            }
        }
    }
}
