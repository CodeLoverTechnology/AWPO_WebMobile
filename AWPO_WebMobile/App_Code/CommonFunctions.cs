using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AWPO_WebMobile.App_Code
{
    public class CommonFunctions
    {
        public static bool IsFolderExist(string FolderPathFromResource)
        {
            try
            {
                if (!Directory.Exists(Path.GetFullPath(FolderPathFromResource)))
                {
                    Directory.CreateDirectory(Path.GetFullPath(FolderPathFromResource));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsFileExist(string NewFileName)
        {
            try
            {
                if (!File.Exists(Path.GetFullPath(NewFileName)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string getVacancyTypeById(int id)
        {
            return Enum.GetValues(typeof(VacancyType)).GetValue(id).ToString();
        }

        public static bool CheckUserAuthentication()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            HttpContext.Current.Response.Cache.SetNoStore();
            if (HttpContext.Current.Session["PrCode"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public enum VacancyType
    {
        OfficersVacancies = 1,
        JCO_OCR = 2,
        Govt_Comp = 3
    }


}