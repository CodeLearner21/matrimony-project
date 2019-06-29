﻿using AutoMapper;
using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Infrastructure.Data.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new ResponseError(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }
    }
}