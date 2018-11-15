using MojaApka.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojaApka.Repositories
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
    }
}
