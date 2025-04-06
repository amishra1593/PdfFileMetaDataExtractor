using AutoMapper;
using FileUploaderSample.Domains.Entities;
using FileUploaderSample.Responses.DTOs;

namespace FileUploaderSample.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FileMetaData, FileMetadataDTO>();
            // Add more mappings as needed
        }
    }
}
