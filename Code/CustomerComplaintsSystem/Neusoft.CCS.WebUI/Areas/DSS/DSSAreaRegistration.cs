using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.DSS
{
    public class DSSAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DSS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DSS_default",
                "DSS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
