using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Sahab.Enterprise.HR.Managers.UploadManager
{
    /// <summary>
    /// Upload Manaager that helps in the validation for the uploaded files
    /// </summary>
    public class UploadManager : IUploadManager
    {
        #region Fields
        private ImageConverter _imageConverter;
        #endregion

        #region Ctor
        public UploadManager()
        {
            _imageConverter = new ImageConverter();

        }
        #endregion

        #region Methods
        public string SaveProfilePhoto(HttpFileCollectionBase httpFile, HttpServerUtilityBase server)
        {
            // get Photo to save 
            if (httpFile != null && httpFile.Count > 0)
            {
                var image = httpFile[0]; 
                // check photo 
                if (image.ContentType.Contains("image"))
                {
                    try
                    {
                        // save photo and return the url 
                        var imageExt = image.FileName.LastIndexOf(".") + 1 > image.FileName.Length ? image.FileName.Substring(image.FileName.LastIndexOf(".") + 1) : "png";
                        var imageSaveName = $"{Guid.NewGuid()}.{imageExt}";
                        var path = Path.Combine(server.MapPath("/Content/Uploaded/ProfilePhoto/"), imageSaveName);
                        image.SaveAs(path);
                        return imageSaveName;
                    }
                    catch(Exception x)
                    {
                        return null;
                    }
                } 
            }
            return null;
        }
        #endregion

        #region Helper 
        private enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        private ImageFormat GetImageFormat(byte[] bytes)
        {
            // see http://www.mikekunz.com/image_file_header.html  
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
        #endregion
    }
}