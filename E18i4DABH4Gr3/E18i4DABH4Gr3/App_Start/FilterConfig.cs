using System.Web;
using System.Web.Mvc;

namespace E18i4DABH4Gr3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
