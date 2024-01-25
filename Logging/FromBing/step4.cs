using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PersonRepository
    {
        private readonly PersonContext _context;
        private readonly LoggerService _logger;

        public PersonRepository(PersonContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        // Diğer metotlar...

        public async Task AddPersonAsync(Person person)
        {
            _logger.LogInformation($"Adding person with Id {person.Id}...");
            try
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Person with Id {person.Id} added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding person with Id {person.Id}: {ex.Message}");
                throw;
            }
        }
    }
}
