namespace BoatSystem.Application
{
    using BoatRentalSystem.Core.Interfaces;
    using BoatSystem.Core.Entities;
    using BoatSystem.Core.Interfaces;
    using BoatSystem.Core.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterOwnerCommand : ICommand<AuthModel>
    {
        public RegisterModel Model { get; set; }
        public RegisterOwnerCommand(RegisterModel model)
        {
            Model = model;
        }
    }

    public class RegisterOwnerCommandHandler : ICommandHandler<RegisterOwnerCommand, AuthModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOwnerRepository _ownerRepository;

        public RegisterOwnerCommandHandler(UserManager<ApplicationUser> userManager, IOwnerRepository ownerRepository)
        {
            _userManager = userManager;
            _ownerRepository = ownerRepository;
        }
        public async Task<AuthModel> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;
            if(await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return new AuthModel { Message = "Email is already registered" };
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                return new AuthModel { Message = "UserName is already registered" };
            }


            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new AuthModel { Message = string.Join(", ", result.Errors.Select(e => e.Description))  };
            }

            await _userManager.AddToRoleAsync(user, "Owner");
            var owner = new Owner
            {
                UserId = user.Id,
                IsVerified = false,
            };
            await _ownerRepository.AddAsync(owner);
            return new AuthModel { Message = "Owner registered successfully , please verify account" };
        }
    }



    public class LoginCommand : IRequest<AuthModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IOwnerRepository _ownerRepository;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IAuthService authService, IOwnerRepository ownerRepository)
        {
            _userManager = userManager;
            _authService = authService;
            _ownerRepository = ownerRepository;
        }
        public async Task<AuthModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                authModel.Message = "Email or password is incorrect";
                return authModel;
            }

            var owner = await _ownerRepository.GetByUserIdAsync(user.Id);
            if (user != null && owner != null && !owner.IsVerified)
            {
                authModel.Message = "owner account is not verified";
                return authModel;
            }

            var jwtToken = await _authService.CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.ExpiresOn = jwtToken.ValidTo;
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.Roles = roleList.ToList();
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return authModel;
        }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result Success() => new Result { IsSuccess = true };
        public static Result Failure(string message) => new Result { IsSuccess = false , Message = message};

    }


    public class VerifyOwnerCommand : IRequest<Result>
    {
        public int OwnerId { get; set; }
    }

    public class VerifyOwnerCommandHandler : IRequestHandler<VerifyOwnerCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;

        public VerifyOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task<Result> Handle(VerifyOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(request.OwnerId);
            if(owner == null)
            {
                return Result.Failure("Owner not found");
            }
            owner.IsVerified = true;
            await _ownerRepository.UpdateAsync(owner.Id, owner);

            return Result.Success();
        }
    }
}
