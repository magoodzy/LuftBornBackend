using AutoMapper;
using MarbellaMS.Entities;
using MarbellaMS.IRepositories;
using MarbellaMS.Repositories;
using MarbellaMS.Requests;
using MarbellaMS.Responses;
using MarbellaMS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarbellaMS.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        IUsersRepository _IUsersRepository;
        public UsersController(IUsersRepository IUsersRepository)
        {
            _IUsersRepository = IUsersRepository;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("AddUsers")]
        public  IActionResult AddUsers(AddUsersRequest AddUsersRequest)
        {
            var Data = _IUsersRepository.AddUsers(AddUsersRequest);
            if (Data.Status == "error")
            {
                return BadRequest(Data);
            }
            else
            {
                return Ok(Data);
            }
        }

        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("DeleteUsers")]
        public IActionResult DeleteUsers(int Id)
        {
            var Data = _IUsersRepository.DeleteUsers(Id);
            if (Data.Status == "error")
            {
                return BadRequest(Data);
            }
            else
            {
                return Ok(Data);
            }
        }



        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("EditUsers")]
        public IActionResult EditUsers(EditUsersRequest EditUsersRequest)
        {
            var Data = _IUsersRepository.EditUsers(EditUsersRequest);
            if (Data.Status == "error")
            {
                return BadRequest(Data);
            }
            else
            {
                return Ok(Data);
            }
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("GetUsers")]
        public IActionResult GetUsers(GetUsersRequest GetUsersRequest)
        {
            var Data = _IUsersRepository.GetUsers(GetUsersRequest);
            if (Data.Status == "error")
            {
                return BadRequest(Data);
            }
            else
            {
                return Ok(Data);
            }
        }

    }
}
