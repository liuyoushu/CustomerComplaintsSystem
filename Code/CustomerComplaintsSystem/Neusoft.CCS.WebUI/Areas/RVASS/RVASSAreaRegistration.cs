using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.RVASS
{
    public class RVASSAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RVASS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RVASS_default",
                "RVASS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
