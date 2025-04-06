namespace FileUploaderSample.Services.Contracts
{
    public interface IValidationService
    {
        bool ValidateFileExtention(IFormFile file);
    }
}
