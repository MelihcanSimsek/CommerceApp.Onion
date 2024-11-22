using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? mediator => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMediator? Mediator;

    }
}
