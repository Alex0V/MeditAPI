using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Medit.BLL.Interfaces.Services;
using Medit.BLL.Models;
using Microsoft.AspNetCore.Http;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class StorageService : IStorageService
    {
        public async Task<S3ResponseDto> UploadFileAsync(IFormFile image, AwsCredentials awsCredentials)
        {
            var response = new S3ResponseDto();

            await using var memoryStr = new MemoryStream();
            await image.CopyToAsync(memoryStr);

            var fileExt = Path.GetExtension(image.FileName);
            if (string.IsNullOrEmpty(fileExt))
            {
                response.StatusCode = 400;
                response.Message = $"Path.GetExtension don't get extention({fileExt})";
                return response;
            }
            var objName = $"{Guid.NewGuid()}{fileExt}";
            var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
            };
            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = memoryStr,
                    Key = objName.ToString(),
                    BucketName = "medi-coursework",
                    CannedACL = S3CannedACL.NoACL
                };
                using var client = new AmazonS3Client(credential, config);

                var transferUtility = new TransferUtility(client);
                await transferUtility.UploadAsync(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"file uploaded successfully";
                response.FileName = objName;
            }
            catch(AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }catch(Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<string> GetPrivateImageUrlAsync(string fileName, AwsCredentials awsCredentials)
        {
            var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
            };


            using (var client = new AmazonS3Client(credential, config))
            {
                var request = new Amazon.S3.Model.GetPreSignedUrlRequest
                {
                    BucketName = "medi-coursework",
                    Key = fileName,
                    Expires = DateTime.UtcNow.AddDays(7) // Тривалість дії підписаного URL
                };
                string url = client.GetPreSignedURL(request);
                return url;
            }
        }

        public async Task DeleteFileAsync(string fileName, AwsCredentials awsCredentials)
        {
            var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
            };


            using (var client = new AmazonS3Client(credential, config))
            {
                var request = new Amazon.S3.Model.DeleteObjectRequest
                {
                    BucketName = "medi-coursework",
                    Key = fileName
                };
                await client.DeleteObjectAsync(request);
            }
        }
    }
}
