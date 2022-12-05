using AutoMapper;
using BankManager.Api.Extensions;
using BankManager.Api.Requests;
using BankManager.DataTransferObjects;
using BankManager.Entities;
using BankManager.Services;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManager.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IUserService UserService { get; }

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/byId")]
        public UserDto GetById(int id)
        {
            var entity = UserService.GetById(id);
            var result = _mapper.Map<UserDto>(entity);
            return result;
        }

        [HttpGet]
        [Route("/byEmail")]
        public UserDto GetByEmail(string email)
        {
            var entity = UserService.GetByEmail(email);
            var result = _mapper.Map<UserDto>(entity);
            return result;
        }

        [HttpPost]
        public UserDto CreateUser(UserRequest request)
        {
            var createdEntity = UserService.CreateUser(_mapper.Map<UserEntity>(request));
            var result = _mapper.Map<UserDto>(createdEntity);
            return result;
        }

        [HttpPut]
        public UserDto UpdateUser(UserRequest request)
        {
            var createdEntity = UserService.UpdateUser(_mapper.Map<UserEntity>(request));
            var result = _mapper.Map<UserDto>(createdEntity);
            return result;
        }


        [HttpDelete]
        public void DeleteUser(int userId)
        {
            UserService.DeleteUser(userId);
        }
    }
}
