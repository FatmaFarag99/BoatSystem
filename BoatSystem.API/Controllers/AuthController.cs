namespace BoatSystem.API.Controllers
{
    using BoatSystem.Application;
    using BoatSystem.Core.Interfaces;
    using BoatSystem.Core.Models;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;

        public AuthController(IAuthService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }




        [HttpPost("register-owner")]
        public async Task<IActionResult> RegisterOwner(RegisterOwnerCommand command)
        {
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }



        [HttpPost("verify-owner")]
        public async Task<IActionResult> VerifyOwner(VerifyOwnerCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _authService.RegisterAsync(model);
        //    if (!result.IsAuthenticated)
        //        return BadRequest(result.Message);

        //    return Ok(result);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] TokenRequestModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _authService.Login(model);
        //    if (!result.IsAuthenticated)
        //        return BadRequest(result.Message);

        //    return Ok(result);
        //}
    }
}
