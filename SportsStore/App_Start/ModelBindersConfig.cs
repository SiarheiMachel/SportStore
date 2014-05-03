using System.Web.Mvc;
using SportsStore.Web.Binders;
using SportsStore.Web.Models;

namespace SportsStore.Web
{
    public class ModelBindersConfig
    {
        public static void RegisterModelBinders()
        {
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}