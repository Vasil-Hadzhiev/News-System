namespace NewsSystem.Web.Attributes
{
    using System.Linq;
    using System.Web.Mvc;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            string[] roles = this.Roles.Split(',');

            bool isAuthenticated = context.HttpContext.Request.IsAuthenticated;
            bool hasRole = roles.Any(s => context.HttpContext.User.IsInRole(s));

            if (isAuthenticated && !hasRole)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorize.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(context);
            }
        }
    }
}