namespace AdventureWorks2019BE.DTOs.SigeoDTOs
{
    public class UserDTO : BaseDTO<long>
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
