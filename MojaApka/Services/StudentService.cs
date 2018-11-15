using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojaApka.Domains;
using MojaApka.Repositories;

namespace MojaApka.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateStudent(string name)
        {
            var student = new Student();
            student.Name = name;
            student.IndexNumber = 11085;
            await _studentRepository.AddAsync(student);
        }
    }
}
