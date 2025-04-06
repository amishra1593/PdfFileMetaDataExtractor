using FileUploaderSample.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using FileMetaData = FileUploaderSample.Domains.Entities.FileMetaData;

namespace FileUploaderSample.Infrastructure.EFConfig
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FileMetaData> Files { get; set; }
    }
}
