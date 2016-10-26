using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharingApplication.Filters
{
    public class ControllerActionAuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.logValues(filterContext.RouteData);
        }

        private void logValues(RouteData routeData)
        {
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];
            string message = string.Format("Controller: {0}; Action: {1}", controller, action);
            Debug.WriteLine(message, "Action Values");

            foreach (var item in routeData.Values)
            {
                Debug.WriteLine(">> Key: {0}; Value {1}", item.Key, item.Value);
            }
        }
    }
}