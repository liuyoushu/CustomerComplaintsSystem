using System.Web.Mvc;

namespace Neusoft.CCS.WebUI.Areas.CHS
{
    public class CHSAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CHS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CHS_default",
                "CHS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
