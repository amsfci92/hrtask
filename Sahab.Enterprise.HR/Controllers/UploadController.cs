using Sahab.Enterprise.HR.Managers.UploadManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahab.Enterprise.HR.Controllers
{
    /// <summary>
    /// Upload Profile Images to Server 
    /// </summary>
    [RoutePrefix("U")]
    public class UploadController : Controller
    {
        #region Fields
        IUploadManager _uploadManager;
        #endregion

        #region Ctor
        public UploadController(IUploadManager uploadManager)
        {
            _uploadManager = uploadManager;
        }
        #endregion

        #region Method
        [HttpPost]
        [Route("S")]
        public ActionResult SaveProfilePhoto()
        {
            var images = Request.Files;
            var imageUrl = _uploadManager.SaveProfilePhoto(images, Server);

            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return HttpNotFound();
            }
            return Json(new
            {
                url = imageUrl
            });
        }
        #endregion
    }
}
