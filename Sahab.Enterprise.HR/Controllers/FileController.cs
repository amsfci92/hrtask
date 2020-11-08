using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace Sahab.Enterprise.HR.Controllers
{
    /// <summary>
    /// File Manager to get the files without let anyone know the structure of the file uploading
    /// </summary>
    [RoutePrefix("f")]
    public class FileController : Controller
    {
        /// <summary>
        /// Get the Profile Image
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Route("pi")]
        public ActionResult Index(string url)
        {
            var def = "/Content/assets2/img/arashmil.jpg";
            var file = new FileInfo(Server.MapPath($"/Content/Uploaded/ProfilePhoto/{url}"));
            if (file.Exists)
            {
                var fileBytes = System.IO.File.ReadAllBytes(file.FullName);
                return File(fileBytes, "Image/png", file.Name);
            }
           
            file = new FileInfo(Server.MapPath(def));

            if (file.Exists)
            {
                var defFileBytes = System.IO.File.ReadAllBytes(file.FullName);
                return File(defFileBytes, "Image/png", file.Name);
            }

            return HttpNotFound();
        }
    }
}
