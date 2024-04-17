using System.Web;
using System.Web.Mvc;

namespace TVM_bài_hướng_dẫn_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
