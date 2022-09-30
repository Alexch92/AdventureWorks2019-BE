using AutoMapper;
using AdventureWorks2019BE.DTOs.SigeoDTOs;
using AdventureWorks2019BE.Entities.SigeoEntities;
using AdventureWorks2019BE.Mappers.SigeoMappers;
using AdventureWorks2019BE.Repositories.SigeoRepositories;

namespace AdventureWorks2019BE.Services
{
    public class UserService : BaseService<UserRepository>
    {
        public readonly IMapper _mapperUser;

        public UserService(IMapper mapperUser)
        {
            this._mapperUser = mapperUser;
        }

        public async Task<UserDTO> getById(long id)
        {
            User user = await this.repository.findById(id);
            return this._mapperUser.Map<UserDTO>(user);
        }
    }
}
