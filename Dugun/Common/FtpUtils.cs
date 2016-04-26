using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace Dugun.Common
{
    public static class FtpUtils
    {
        private static string UserName_;
        public static string UserName
        {
            get
            {
                if (UserName_ == null)
                {
                    UserName_ = WebConfigurationManager.AppSettings["ContentServerFtpUserName"];
                }
                return UserName_;
            }
        }
        
        private static string Password_;
        public static string Password
        {
            get
            {
                if (Password_ == null)
                { 
                    Password_ = WebConfigurationManager.AppSettings["ContentServerFtpPassword"];
                }
                return Password_;
            }
        }
        
        public static bool FtpCreateDirectory(Uri url)
        {
            try
            {
                if (!FtpDirectoryExists(url))
                {
                    FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(url);
                    ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);
                    ftpWebRequest.UsePassive = true;
                    ftpWebRequest.UseBinary = true;
                    ftpWebRequest.KeepAlive = false;

                    FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                    Stream stream = ftpWebResponse.GetResponseStream();
                    stream.Close();
                    ftpWebResponse.Close();
                }

                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse ftpWebResponse = (FtpWebResponse)ex.Response;
                if (ftpWebResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    ftpWebResponse.Close();
                    return true;
                }
                else
                {
                    ftpWebResponse.Close();
                    return false;
                }
            }
        }
       
        public static bool FtpDirectoryExists(Uri url)
        {
            if (url.Scheme != Uri.UriSchemeFtp)
                return false;

            bool isExists = true;
            try
            {
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(url);
                ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                isExists = false;
            }

            return isExists;
        }

        public static bool FtpDeleteFile(Uri url)
        {
            if (url.Scheme != Uri.UriSchemeFtp)
                return false;

            try
            {
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(url);
                ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UploadToDirectory(string ftpMainDirectory, string sourcePath, bool addFileName, string[] extraFolders)
        {
            #region Create Extra Folders

            string ftpPath = ftpMainDirectory;
            foreach (var extraFolder in extraFolders)
            {
                ftpPath += extraFolder + "/";
                FtpCreateDirectory(new Uri(ftpPath));
            }
                
            #endregion
            
            FileInfo fileInfo = new FileInfo(sourcePath);
            
            FtpDeleteFile(new Uri(ftpPath + fileInfo.Name));

            FtpWebRequest ftpWebRequest;

            // Create FtpWebRequest object 
            if(addFileName)
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileInfo.Name, UriKind.Absolute));
            else
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath, UriKind.Absolute));

            // Set Credintials
            ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            ftpWebRequest.KeepAlive = false;

            // Set the data transfer type.
            ftpWebRequest.UseBinary = true;

            // Set content length
            ftpWebRequest.ContentLength = fileInfo.Length;

            // Set request method
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

            // Set buffer size
            int bufferLenght = 16 * 1024;
            byte[] buffer = new byte[bufferLenght];

            // Opens a file to read
            FileStream fileStream = fileInfo.OpenRead();

            bool result = false;
            Stream stream = null;
            try
            {
                // Get Stream of the file
                stream = ftpWebRequest.GetRequestStream();

                int len = 0;

                while ((len = fileStream.Read(buffer, 0, bufferLenght)) != 0)
                {
                    // Write file Content 
                    stream.Write(buffer, 0, len);
                }

                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if(stream != null)
                    stream.Close();
                
                fileStream.Close();
                fileStream.Dispose();
            }

            return result;
        }
    }
}