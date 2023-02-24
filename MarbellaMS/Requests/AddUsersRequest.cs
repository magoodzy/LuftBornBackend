namespace MarbellaMS.Requests
{
    public class AddUsersRequest
    {
        public int DeptId { get; set; }
        public int PosId { get; set; }
        public string FullEnglishName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
