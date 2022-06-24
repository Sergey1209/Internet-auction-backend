using Microsoft.AspNetCore.Mvc;

namespace InternetAuction.Extensions
{
    public static class ControllerBaseExtension
    {
        public static ActionResult<T> GetResult<T>(this ControllerBase controller, T result) where T : class
        {
            if (result == null)
                return controller.NotFound();

            return controller.Ok(result);
        }
    }
}
