using MISA.DemoDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DemoDapper.IServices
{
    /// <summary>
    /// Interface xử lý logic cho sinh viên
    /// Created by: MTHUNG (11/10/2020)
    /// </summary>
    public interface IStudentService
    {
        Student Insert(Student oStudent);
        List<Student> Gets();
        Student Get(string studentId);
        Student Update(Student oStudent);
        Student Delete(string studentId);

    }
}
