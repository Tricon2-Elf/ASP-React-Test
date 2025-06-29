using System.Globalization;

namespace dataComTest.Server
{
    public class Utils
    {
        public static string GetCountryNameByID(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                    return new RegionInfo(id).EnglishName;
                else
                    throw new ArgumentException("Invalid Country Code");
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}
