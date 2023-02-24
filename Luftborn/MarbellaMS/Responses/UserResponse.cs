using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarbellaMS.Responses
{
    public class UserResponse<T>
    {
        public UserResponse()
        {

        }
        public string Status { get; set; }
        public string Message { get; set; }
        public T data { set; get; }



    }
}
