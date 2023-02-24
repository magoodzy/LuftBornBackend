using System;
using MarbellaMS.Entities;
using MarbellaMS.IRepositories;
using MarbellaMS.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarbellaMS.Requests;
using AutoMapper;
using System.Runtime.Intrinsics.Arm;
using MarbellaMS.ViewModel;

namespace MarbellaMS.Repositories
{
    public class UsersRepository:IUsersRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly IMapper _mapper;

        public UsersRepository(ApplicationDbContext ApplicationDbContext, IMapper IMapper)
        {
            _ApplicationDbContext = ApplicationDbContext;
            _mapper = IMapper;
        }


        public  UserResponse<AddUsersRequest> AddUsers (AddUsersRequest AddUsersRequest)
        {
            UserResponse<AddUsersRequest> UserResponse = new();
            Users users = new Users();

            try
            {
                var isExist = _ApplicationDbContext.Users.Where(obj => obj.PhoneNumber == AddUsersRequest.PhoneNumber).FirstOrDefault();

                if(isExist != null)
                {
                    UserResponse.Status = "error";
                    UserResponse.Message = "User Number Exists Before!";
                    UserResponse.data = null;

                    return UserResponse;
                }

                var Map = _mapper.Map(AddUsersRequest, users);
                _ApplicationDbContext.Users.Add(users);
                _ApplicationDbContext.SaveChanges();

                UserResponse.Status = "success";
                UserResponse.Message = "User Added Successfully!";
                UserResponse.data = AddUsersRequest;


            }
            catch (Exception e)
            {

                UserResponse.Status = "error";
                UserResponse.Message = "Something Went Wrong!, "+e.Message;
                UserResponse.data = null;

            }

            return UserResponse;
        }
        public UserResponse<Users> DeleteUsers(int Id)
        {
            UserResponse<Users> UserResponse = new();

            try
            {
                var User = _ApplicationDbContext.Users.Where(obj => obj.Id == Id).FirstOrDefault();

                if (User == null)
                {
                    UserResponse.Status = "error";
                    UserResponse.Message = "User Not Exists!";
                    UserResponse.data = null;

                    return UserResponse;
                }


                _ApplicationDbContext.Users.Remove(User);
                _ApplicationDbContext.SaveChanges();

                UserResponse.Status = "success";
                UserResponse.Message = "User Deleted Successfully!";
                UserResponse.data = User;

            }
            catch (Exception e)
            {

                UserResponse.Status = "error";
                UserResponse.Message = "Something Went Wrong!, " + e.Message;
                UserResponse.data = null;

            }

            return UserResponse;
        }
        public UserResponse<EditUsersRequest> EditUsers(EditUsersRequest EditUsersRequest)
        {
            UserResponse<EditUsersRequest> UserResponse = new();

            try
            {
                var User = _ApplicationDbContext.Users.Where(obj => obj.Id == EditUsersRequest.Id).FirstOrDefault();

                if (User == null)
                {
                    UserResponse.Status = "error";
                    UserResponse.Message = "User Not Exists!";
                    UserResponse.data = null;

                    return UserResponse;
                }

                _ApplicationDbContext.Entry(User).CurrentValues.SetValues(EditUsersRequest);
                _ApplicationDbContext.SaveChanges();

                UserResponse.Status = "success";
                UserResponse.Message = "User Updated Successfully!";
                UserResponse.data = EditUsersRequest;

            }
            catch (Exception e)
            {

                UserResponse.Status = "error";
                UserResponse.Message = "Something Went Wrong!, " + e.Message;
                UserResponse.data = null;

            }

            return UserResponse;
        }


        public UserResponse<List<GetUsersViewModel>>  GetUsers(GetUsersRequest GetUsersRequest)
        {
            UserResponse<List<GetUsersViewModel>> UserResponse = new();
            try
            {
                var Users = (from User in _ApplicationDbContext.Users
                             join Departments in _ApplicationDbContext.Departments on User.DeptId equals Departments.Id
                             join Positions in _ApplicationDbContext.Positions on User.PosId equals Positions.Id
                             select new GetUsersViewModel
                             {
                                 Id=User.Id,
                                 Department=Departments.DeptName,
                                 DeptId= User.DeptId,
                                 FullEnglishName= User.FullEnglishName,
                                 PhoneNumber= User.PhoneNumber,
                                 PosId= User.PosId,
                                 Position=Positions.PosName
                             }
                           ).ToList();

                if (GetUsersRequest.Id != 0)
                {
                    Users = Users.Where(obj => obj.Id == GetUsersRequest.Id).ToList();
                }


                UserResponse.Status = "success";
                UserResponse.Message = "User Retrieved Successfully!";
                UserResponse.data = Users;
            }
            catch (Exception e)
            {
                UserResponse.Status = "error";
                UserResponse.Message = "Something Went Wrong!, " + e.Message;
                UserResponse.data = null;

            }

            return UserResponse;
        }



    }
}
