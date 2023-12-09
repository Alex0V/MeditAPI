using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Medit.BLL.Interfaces.Services;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class StorageService : IStorageService
    {
        public async Task<S3ResponseDto> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials)
        {
            var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
            };

            var response = new S3ResponseDto();

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3obj.InputStream,
                    Key = s3obj.Name,
                    BucketName = s3obj.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };
                using var client = new AmazonS3Client(credential, config);

                var transferUtility = new TransferUtility(client);
                await transferUtility.UploadAsync(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"{s3obj.Name} has been uploaded successfully";
            }catch(AmazonS3Exception ex)
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

        public async Task<string> GetPrivateImageUrl(S3Object s3obj, AwsCredentials awsCredentials)
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
                    BucketName = s3obj.BucketName,
                    Key = s3obj.Name,
                    Expires = DateTime.UtcNow.AddHours(1) // Тривалість дії підписаного URL
                };

                string url = client.GetPreSignedURL(request);
                return url;
            }
        }

    }
}
