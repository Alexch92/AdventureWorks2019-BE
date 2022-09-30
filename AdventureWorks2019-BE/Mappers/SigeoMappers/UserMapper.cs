
namespace AdventureWorks2019BE.Mappers.SigeoMappers
{
    public class UserMapper : BaseMapper, IConvertible
    {
        public UserMapper()
        {
            this.FieldsDictionary = new Dictionary<string, string>()
            {
                { "id", "_Id"},
                { "login", "Login"},
                { "password_hash", "PasswordHash"},
                { "first_name", "FirstName"},
                { "last_name", "LastName"}
            };
        }
    }
}
