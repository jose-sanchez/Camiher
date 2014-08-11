using System.Web.Mvc;

namespace WEBCAMIHER.Areas.Handlers
{
    public class HandlersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Handlers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Handlers_default",
                "Handlers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
