using FileUploaderSample.Domains.Entities;
using FileUploaderSample.Infrastructure.EFConfig;
using FileUploaderSample.Infrastructure.Repository.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;

namespace FileUploaderSample.Infrastructure.Repository.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _context;
        public FileRepository(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public async Task SaveFileToDatabase(FileMetaData file)
        {   
            try
            {  
                await _context.Files.AddAsync(file);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<FileMetaData>> GetAllAsync(string? search)
        {
            try
            {
                IQueryable<FileMetaData> query = _context.Files.AsNoTracking();

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(f => f.Title.Contains(search) || f.Author.Contains(search));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
