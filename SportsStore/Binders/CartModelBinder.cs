using System;
using System.Web.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string CartSessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Session != null)
            {
                var cart = controllerContext.HttpContext.Session[CartSessionKey] as Cart;

                if (cart == null)
                {
                    cart = new Cart();
                    controllerContext.HttpContext.Session[CartSessionKey] = cart;
                }

                return cart;
            }

            throw new Exception("controller context doesn't contain session object");
        }
    }
}