using MarbellaMS.Entities;
using MarbellaMS.Requests;
using MarbellaMS.Responses;
using MarbellaMS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarbellaMS.IRepositories
{
    public interface IUsersRepository
    {
        public   UserResponse<AddUsersRequest> AddUsers(AddUsersRequest AddUsersRequest);
        public UserResponse<Users> DeleteUsers(int Id);
        public UserResponse<EditUsersRequest> EditUsers(EditUsersRequest EditUsersRequest);
        public UserResponse<List<GetUsersViewModel>> GetUsers(GetUsersRequest GetUsersRequest);

    }
}
