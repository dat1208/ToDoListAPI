using System.Web.Http;

namespace ToDoListAPI.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableCors();

            
        }
    }
}
