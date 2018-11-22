using MojaApka.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojaApka.Services
{
    public interface IStudentService
    {
        Task CreateStudent(string name);
        Task<IEnumerable<Student>> GetAll();
    }
}
