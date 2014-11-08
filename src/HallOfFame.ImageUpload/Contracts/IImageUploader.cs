namespace HallOfFame.ImageUpload.Contracts
{
    using System.IO;

    public interface IImageUploader
    {
        string UrlFromBase64Image(string base64, string fileType);

        string UrlFromMemoryStream(MemoryStream imageStream, string fileType);
    }
}