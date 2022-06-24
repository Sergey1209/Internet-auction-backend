using Business.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace InternetAuction.Validation
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is AuctionBusinessException ex_auction)
            {
                context.Result = new BadRequestObjectResult(ex_auction.Message);
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception ex)
            {
                context.Result = new BadRequestObjectResult(ex.Message);
                context.ExceptionHandled = true;
            }
        }
    }
}