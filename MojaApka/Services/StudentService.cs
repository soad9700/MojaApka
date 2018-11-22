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
            var students = await _studentRepository.GetAll();
            var highestIndexNumer = 1;
            if (!students.Any())
                student.IndexNumber = highestIndexNumer;
            else
            {
                foreach (var Student in students)
                {
                    if (Student.IndexNumber > highestIndexNumer)
                        highestIndexNumer = Student.IndexNumber;
                }
                student.IndexNumber = highestIndexNumer + 1;
            }

            await _studentRepository.AddAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentRepository.GetAll();
        }
    }
}
