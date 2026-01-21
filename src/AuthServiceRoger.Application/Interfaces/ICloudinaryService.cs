using AuthServiceRoger.Application.Interfaces;

namespace AuthServiceRoger.Application.DTOs;
public interface ICloudinaryService
{
    Task<String> UploadImageAsync(IFileData imagenFile, string fileName);
    Task<bool> DeleteImageAsync(string publicId);
    string GetDefaultAvatarUrl();
    string GetFullImageUrl(string imagePath);
}