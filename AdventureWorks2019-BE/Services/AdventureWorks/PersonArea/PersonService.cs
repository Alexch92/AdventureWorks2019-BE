using AdventureWorks2019BE.Data;
using AdventureWorks2019BE.DTOs.AdventureWorks.PersonArea;
using AdventureWorks2019BE.Repositories.AdventureWorks.PersonArea;
using AutoMapper;

namespace AdventureWorks2019BE.Services.AdventureWorks.PersonArea
{
    public class PersonService //: BaseService<PersonRepository>
    {
        public readonly IMapper _mapper;
        public readonly PersonRepository _personRepository;

        public PersonService(IMapper mapper, PersonRepository personRepository)
        {
            this._mapper = mapper;
            this._personRepository = personRepository;
        }

        public async Task<PersonDTO> GetById(int id)
        {
            Person person = await this._personRepository.FindById(id);
            PersonDTO personDTO = _mapper.Map<PersonDTO>(person);
            return personDTO;
        }
    }
}
