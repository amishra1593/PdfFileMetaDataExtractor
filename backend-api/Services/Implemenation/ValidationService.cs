using FileUploaderSample.Services.Contracts;

namespace FileUploaderSample.Services.Implemenation
{
    public class ValidationService : IValidationService
    {
        public bool ValidateFileExtention(IFormFile file)
        {
            if (file == null || file.Length == 0 || Path.GetExtension(file.FileName).ToLower() != Constants.Constants.FileExterntions.PDF)
            {                
                return false;
            }
            return true;
        }
    }
}
