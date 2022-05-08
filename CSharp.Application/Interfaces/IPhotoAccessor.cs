using CSharp.Application.Photos;
using Microsoft.AspNetCore.Http;

namespace CSharp.Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
