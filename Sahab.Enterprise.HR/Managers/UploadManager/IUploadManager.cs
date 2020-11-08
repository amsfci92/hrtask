using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sahab.Enterprise.HR.Managers.UploadManager
{
    public interface IUploadManager
    {
        string SaveProfilePhoto(HttpFileCollectionBase images, HttpServerUtilityBase server);
    }
}