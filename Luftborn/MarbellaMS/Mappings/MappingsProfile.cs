using AutoMapper;
//using MarbellaMS.Authentication;
//using MarbellaMS.DTOS;
using MarbellaMS.Entities;
using MarbellaMS.Models;
using MarbellaMS.Repositories;
using MarbellaMS.Requests;
//using MarbellaMS.ViewModel;
//using MarbellaMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarbellaMS.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<AddUsersRequest, Users>();

            

        }
    }
}
