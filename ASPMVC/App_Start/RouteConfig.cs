// Программы, игры и их исходные коды
// www.interestprograms.ru

using System.Web.Mvc;
using System.Web.Routing;

namespace ASPMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default", // Название маршрута
                url: "{controller}/{action}/{id}", // Структура маршрута

                // Заполнение маршрутов по умолчанию
                defaults: new { controller = "Animals", /*метод*/action = "Index", /*дополнительный параметр*/id = UrlParameter.Optional }
            );
        }
    }
}
