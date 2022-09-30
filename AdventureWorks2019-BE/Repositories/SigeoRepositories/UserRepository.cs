using AdventureWorks2019BE.Entities.SigeoEntities;
using AdventureWorks2019BE.Mappers.SigeoMappers;

namespace AdventureWorks2019BE.Repositories.SigeoRepositories
{
    public class UserRepository : NpglBaseRepository<User, UserMapper, long>
    {
        List<User> Users;

        public UserRepository()
        {
            Users = new List<User>();
        }

    }
}
