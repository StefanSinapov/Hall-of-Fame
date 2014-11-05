namespace HallOfFame.ImageUpload
{
    using System;
    using System.IO;

    using HallOfFame.Common;
    using HallOfFame.ImageUpload.Contracts;

    using Telerik.Everlive.Sdk.Core;
    using Telerik.Everlive.Sdk.Core.Query.Definition.FormData;

    public class ImageUploader : IImageUploader
    {
        private readonly EverliveApp app;

        // TODO: remove after ninject
        public ImageUploader()
            : this(new EverliveApp(ApiKeys.EverliveAppKey))
        {
        }

        public ImageUploader(EverliveApp everliveApp)
        {
            this.app = everliveApp;
        }

        public string UrlFromBase64Image(string base64)
        {
            var stream = new MemoryStream(Convert.FromBase64String(base64));
            var uploadResult = this.app.WorkWith().Files().Upload(new FileField("Url", Guid.NewGuid().ToString(), "image/jpeg", stream)).ExecuteSync();
            var url = this.app.WorkWith().Files().GetFileDownloadUrl(uploadResult.Id);

            // var url = this.app.WorkWith().Files().GetById(uploadResult.Id).ExecuteSync()["URL"];
            return url;
        }

        public string UrlFromMemoryStream(MemoryStream imageStream)
        {
            var uploadResult = this.app.WorkWith().Files().Upload(new FileField("Url", Guid.NewGuid().ToString(), "image/jpeg", imageStream)).ExecuteSync();
            return this.app.WorkWith().Files().GetFileDownloadUrl(uploadResult.Id);
        }
    }
}