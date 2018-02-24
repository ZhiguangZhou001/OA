using System.Web.Mvc;

namespace ZZTOA.Areas.option
{
    public class optionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "option";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "option_default",
                "option/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}