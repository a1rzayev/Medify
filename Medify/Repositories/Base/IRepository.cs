using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medify.Models;

namespace Medify.Repositories.Base
{
    public interface IRepository
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor? GetDoctorById(int id);
        public Doctor? GetDoctorByName(string name);
        public int AddDoctor(Doctor doctor);
        public int DeleteDoctor(int id);
    }
}
