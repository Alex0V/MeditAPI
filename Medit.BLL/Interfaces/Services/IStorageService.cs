using WebAPI.Models;

namespace Medit.BLL.Interfaces.Services
{
    public interface IStorageService
    {
        Task<S3ResponseDto> UploadFileAsync(S3Object file, AwsCredentials awsCredentials);
        Task<string> GetPrivateImageUrl(S3Object s3obj, AwsCredentials awsCredentials);
    }
}
