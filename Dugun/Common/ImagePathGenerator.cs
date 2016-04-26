using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Dugun.Common
{
    public class ImagePathGenerator
    {
        public static string GetTemporaryFilePath(string imageName)
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Tempfiles/") + imageName;
        }

        public static string GetImagePath(int? imageID, string imageName, int imageType)
        {
            if (string.IsNullOrEmpty(imageName))
                return null;

            string contentServerUrl = WebConfigurationManager.AppSettings["ContentServerUrl"].ToString();

            string subFolder = "";
            
            switch (imageType)
            {
                case (int)Enums.FileType.UPLOAD :
                    subFolder = WebConfigurationManager.AppSettings["ContentServerUploadFolder"] + "/";
                    break;
                case (int)Enums.FileType.POST:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPostFolder"] + "/";
                    break;
                case (int)Enums.FileType.PRESS:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPressFolder"] + "/";
                    break;
            }

            return contentServerUrl + subFolder + GenereteExtraFolder(imageID) + imageName;
        }

        public static string GetImageFtpPath(int? imageID, string imageName, int imageType)
        {
            string ftpUrl = WebConfigurationManager.AppSettings["ContentServerFtpUrl"];
            string subFolder = "";
            
            switch (imageType)
            {
                case (int)Enums.FileType.UPLOAD:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerUploadFolder"] + "/";
                    break;
                case (int)Enums.FileType.POST:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPostFolder"] + "/";
                    break;
                case (int)Enums.FileType.PRESS:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPressFolder"] + "/";
                    break;
            }

            return ftpUrl + subFolder + GenereteExtraFolder(imageID) + imageName;
        }

        public static string GetContentPath(int imageType)
        {
            string contentUrl = WebConfigurationManager.AppSettings["ContentServerUrl"];
            string subFolder = "";

            switch (imageType)
            {
                case (int)Enums.FileType.UPLOAD:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerUploadFolder"] + "/";
                    break;
                case (int)Enums.FileType.POST:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPostFolder"] + "/";
                    break;
                case (int)Enums.FileType.PRESS:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPressFolder"] + "/";
                    break;
            }

            return contentUrl + subFolder;
        }

        public static string GetFtpPath(int imageType)
        {
            string contentUrl = WebConfigurationManager.AppSettings["ContentServerFtpUrl"];
            string subFolder = "";

            switch (imageType)
            {
                case (int)Enums.FileType.UPLOAD:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerUploadFolder"] + "/";
                    break;
                case (int)Enums.FileType.POST:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPostFolder"] + "/";
                    break;
                case (int)Enums.FileType.PRESS:
                    subFolder = WebConfigurationManager.AppSettings["ContentServerPressFolder"] + "/";
                    break;
            }

            return contentUrl + subFolder;
        }

        public static string GenereteExtraFolder(int? imageID)
        {
            if (imageID != null && imageID > 0)
                return (imageID % 97).ToString() + "/";
                //return (imageID % 983).ToString() + "/" + (imageID % 991).ToString() + "/" + (imageID % 997).ToString() + "/";
            else
                return "";
        }

        public static void UploadImageToFtp(int imageID, string imageName, int imageType)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                imageName = imageName.Replace("\"", "");
                string filePath = GetTemporaryFilePath(imageName);

                if (File.Exists(filePath))
                {
                    string ftpPath = GetFtpPath(imageType);
                    string extraFolderPath = GenereteExtraFolder(imageID).TrimEnd('/');
                    FtpUtils.UploadToDirectory(ftpPath, filePath, true, extraFolderPath.Split('/'));
                    
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(filePath);
                }
            }
        }
    }
}