using Medit.BLL.Models;
using Microsoft.AspNetCore.Http;
using WebAPI.Models;

namespace Medit.BLL.Interfaces.Services
{
    public interface IStorageService
    {
        Task<S3ResponseDto> UploadFileAsync(IFormFile image, AwsCredentials awsCredentials);
        Task<string> GetPrivateImageUrlAsync(string fileName, AwsCredentials awsCredentials);
        Task DeleteFileAsync(string fileName, AwsCredentials awsCredentials);

    }
}
