using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AGSR.Patients.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected async Task<ActionResult<TRespone>> ValidateRequest<TRequest, TRespone>(
            TRequest request,
            IValidator<TRequest> validator,
            Func<TRequest, Task<TRespone>> apiFunc)
        {
            var validationResult = await validator.ValidateAsync(request);

            return validationResult.IsValid
                ? Ok(apiFunc(request))
                : BadRequest(validationResult);
        }
    }
}
