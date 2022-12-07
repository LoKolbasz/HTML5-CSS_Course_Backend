using System.ComponentModel.DataAnnotations;
using HTML5_CSS_Course_Backend_Logic;
using Microsoft.AspNetCore.Mvc;
using HTML5_CSS_Course_Backend_Models;
using Microsoft.AspNetCore.Diagnostics;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    public static class ControllerHelper
    {
        public static IActionResult GetStatusCode(Exception e, ControllerBase cont)
        {
            if (e is ValidationException) //400
            {
                var exceptionHandler = cont.HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                List<Exception> errors = GetInnerExceptions(e);
                return cont.BadRequest(new ApiError(exceptionHandler!.Path, e.Message, errors.ToArray()));
            }
            else if (e is ExpiredTokenException) return cont.Unauthorized(); //401
            else if (e is AuthorizationException) return cont.Forbid(); //403
            else if (e is AuthenticationException) return cont.StatusCode(302); //302
            else if (e is NullReferenceException || e is ArgumentException || e is QuerryFailedException) return cont.StatusCode(500); //500
            return cont.NotFound();
        }
        private static List<Exception> GetInnerExceptions(Exception e)
        {
            List<Exception> l = new List<Exception>();
            l.Add(e);
            while (e.InnerException != null)
            {
                e = e.InnerException;
                l.Add(e);
            }
            return l;
        }
    }
}