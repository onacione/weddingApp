//using Microsoft.AspNet.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Net.Mail;

namespace Dugun.Common
{
    public static class Utils
    {
        public static CultureInfo Culture = new CultureInfo("tr-TR");

        private static string VersionQuery_ { get; set; }

        public static string VersionQuery
        {
            get
            {
                if (VersionQuery_ == null)
                {
                    VersionQuery_ = System.Configuration.ConfigurationManager.AppSettings["VersionQuery"];
                }
                return VersionQuery_;
            }
            set
            {
                VersionQuery_ = value;
            }
        }

        public static string GetMediaUrl(string username, string width, string height)
        {
            //if (media == null || media.MediaID == 0 || string.IsNullOrEmpty(media.FileName) || string.IsNullOrEmpty(width) || string.IsNullOrEmpty(height)) return "//vs.Memursenplorer.com/noimage.png"; else return "//vs.Memursenplorer.com/" + media.FileName.Replace(".jpg", string.Empty) + "/" + media.MediaID + "/" + width + "x" + height + "/" + UrlEncode(media.MediaKeyword).MaxString(70) + ".jpg";
            return "//cdn1.Memursen.me/" + width + "x" + height + "/" + username + ".jpg";
        }

        public static string GetDateAndTime (DateTime _date)
        {
            string result;
            DateTime date2 = DateTime.Now;
            if (date2.Year > _date.Year){
                result = Convert.ToString(_date.Day) + " " + GetMonth(_date.Month) + " " + _date.Year;
                return result;
            }

            else result = Convert.ToString(_date.Day) + " " + GetMonth(_date.Month);
            return result;
        }

        public static string GetHourAndMinute(DateTime _date)
        {
            string result;
            string resulthour = Convert.ToString(_date.Hour);
            if (_date.Hour < 10) resulthour ="0"+ Convert.ToString(_date.Hour);
            if (_date.Minute < 10) { result = resulthour + ":0" + Convert.ToString(_date.Minute); }
            else result = resulthour +":"+ Convert.ToString( _date.Minute);
            return result;
        
        }

        public static string[]  GetValuesFromCsv( string csvTextLine)
        { 
            string[] result;
 
            char[] ayiricilar = {';'};

            result = csvTextLine.Split(ayiricilar);

            return result;

            //Using:
            //Name = GetValuesFromCsv(exampletext).[0] + GetValuesFromCsv(exampletext).[1];
            //TCKN = GetValuesFromCsv(exampletext).[2];
            //e-mail= GetValuesFromCsv(exampletext).[3];
        }

        public static string GetMonth(int _month)
        { 
            switch (_month)
            {
                case 1 : return "Ocak";

                case 2: return "Şubat";

                case 3: return "Mart";

                case 4: return "Nisan";

                case 5: return "Mayıs";

                case 6: return "Haziran";

                case 7: return "Temmuz";

                case 8: return "Ağustos";

                case 9: return "Eylül";

                case 10: return "Ekim";

                case 11: return "Kasım";

                case 12: return "Aralık";     

            }
            return null;
        }

        public static string UrlEncode(string val)
        {
            if (string.IsNullOrEmpty(val)) return "-";
            return RemoveMultipleCharacter(RemoveSpecialCharacters(HttpUtility.UrlEncode(val.UrlRewrite()).Replace(".", "")));
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, "[^a-zA-Z0-9-.]+", "", System.Text.RegularExpressions.RegexOptions.Compiled);
        }

        public static string RemoveMultipleCharacter(string str, string character = "-")
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[" + character + "]{2,}", options);
            return regex.Replace(str, @"-");
        }

        public static string Decode(string val, string replaceStr)
        {
            return System.Web.HttpUtility.UrlDecode(val);
        }

        public static string Encode(string val)
        {
            return System.Web.HttpUtility.UrlEncode(val);
        }

        public static TimeSpan MaxAge = new TimeSpan(30, 0, 0, 0);

        public static string MaxString(this string value, int maxValue)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Length > maxValue) return value.Substring(0, maxValue);
            return value;
        }

        public static string UrlRewrite(this string value)
        {
            value = value.ToLower();
            value = value.Trim();
            value = value.Replace("ş", "s");
            value = value.Replace("ç", "c");
            value = value.Replace("ü", "u");
            value = value.Replace("ö", "o");
            value = value.Replace("ğ", "g");
            value = value.Replace("ı", "i");
            value = value.Replace(" ", "-");
            value = value.Replace("/", "-");
            value = value.Replace("&", "-");
            value = value.Replace(".", "-");
            value = value.Replace(",", "-");
            value = value.Replace("?", "-");
            value = value.Replace("!", "-");
            value = value.Replace("%", "-");
            value = value.Replace("+", "-");
            value = value.Replace("'", "-");
            value = value.Replace("\"", "");
            value = value.Replace("=", "-");
            value = value.Replace("(", "-");
            value = value.Replace(")", "-");
            value = value.Replace("[", "-");
            value = value.Replace("]", "-");
            value = value.Replace("{", "-");
            value = value.Replace("}", "-");
            value = value.Replace(":", "-");
            return value;
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        internal static bool ValidEmail(string p)
        {
            try
            {
                MailAddress m = new MailAddress(p);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool ControlTcNo(string tcNo)
        {
            bool returnValue = false;
            if (tcNo != null && tcNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnValue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }

            return returnValue;
        }

        public static string GetActivityText(int type) {
        switch (type)
        {
            case 0:
                return "size arkadaşlık isteği gönderdi";
            case 1:
                return "arkadaşlık isteğinizi kabul etti";
            default:
                return null;
        }
    }

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetYoutubeLink(string link)
        {
            string result = link.Replace("watch?v=", "v/");
            return result;
        }

        public static string GetYoutubeID(string youTubeUrl)
        {
            //Setup the RegEx Match and give it 
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                               RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return regexMatch.Groups[1].Value;
            }
            return "";
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return htmlRegex.Replace(source, string.Empty);
        }
    }
}