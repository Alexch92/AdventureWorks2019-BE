using AdventureWorks2019BE.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks2019BE.Repositories.AdventureWorks.PersonArea
{
    public class PersonRepository
    {
        AdventureWorks2019Context _context;

        public PersonRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public async Task<Person> FindById(int id)
        {
            Person? query = await _context.Peoples!
                                          //.Include(r => r.PersonPhones)
                                          .Where(x => x.BusinessEntityID == id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

            if (query == null)
                throw new Exception("EntityNotFound");

            return query;
        }
    }
}
