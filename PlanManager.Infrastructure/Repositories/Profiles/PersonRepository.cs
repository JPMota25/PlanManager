using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    private readonly PlanManagerDbContext _context;

    public PersonRepository(PlanManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> VerifyPersonUniqueKeys(Person person)
    {
        Person personDb = await _context.Persons.FirstOrDefaultAsync(x => x.Document == person.Document || x.Email == person.Email);
        return personDb != null;
    }
}