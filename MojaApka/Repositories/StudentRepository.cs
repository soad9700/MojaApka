using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojaApka.Data;
using MojaApka.Domains;

namespace MojaApka.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MojaApkaContext _context;

        public StudentRepository(MojaApkaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Task.FromResult(_context.Students.AsEnumerable());
        }
    }
}
