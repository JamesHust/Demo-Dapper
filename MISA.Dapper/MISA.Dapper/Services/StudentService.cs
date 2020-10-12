using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MISA.Dapper.Common;
using MISA.DemoDapper.IServices;
using MISA.DemoDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DemoDapper.Services
{
    public class StudentService : IStudentService
    {
        Student _oStudent = new Student();
        List<Student> _oStudents = new List<Student>();
        public Student Delete(string studentId)
        {
            _oStudent = new Student();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //// Delete by statement of sql
                    //string sql = "delete from student where StudentID = @StudentID";
                    //DynamicParameters parameters = new DynamicParameters();
                    //parameters.Add("@StudentID", studentId);
                    //var oStudents = con.Query<Student>(sql, parameters);
                    //if (oStudents != null && oStudents.Count() > 0)
                    //{
                    //    _oStudent = oStudents.FirstOrDefault();
                    //}

                    // Delete by Dapper.Contrib
                    _oStudent = con.Get<Student>(studentId);
                    con.Delete<Student>(_oStudent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _oStudent;
        }

        public Student Get(string studentId)
        {
            _oStudent = new Student();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //// Get all by statement of sql
                    //string sql = "select * from student where StudentID = @StudentID";
                    //DynamicParameters parameters = new DynamicParameters();
                    //parameters.Add("@StudentID", studentId);
                    //var oStudents = con.Query<Student>(sql, parameters);
                    //if (oStudents != null && oStudents.Count() > 0)
                    //{
                    //    _oStudent = oStudents.FirstOrDefault();
                    //}

                    // Get all by Dapper.Contrib
                    _oStudent = con.Get<Student>(studentId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _oStudent;
        }

        public List<Student> Gets()
        {
            _oStudents = new List<Student>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //// Get all by statement of sql
                //string sql = "select * from student";
                //var oStudents = con.Query<Student>(sql).ToList();
                //if (oStudents != null && oStudents.Count() > 0)
                //{
                //    _oStudents = oStudents;
                //}

                // Get all by Dapper.Contrib
                IEnumerable<Student> list = con.GetAll<Student>();
                _oStudents = list.ToList();
            }
            return _oStudents;
        }

        public Student Insert(Student oStudent)
        {
            _oStudent = new Student();
            oStudent.CreatedDate = DateTime.Now;
            oStudent.ModifiedDate = oStudent.CreatedDate;
            try
            {
                //int operationType = Convert.ToInt32(oStudent.StudentID == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    // Insert by statement of sql
                    //string sql = "insert into student(StudentID, StudentCode, StudentName, Birthday, Email, Address, CreatedDate, ModifiedDate) values(@StudentID, @StudentCode, @StudentName, @Birthday, @Email, @Address, @CreatedDate, @ModifiedDate)";
                    //var oStudents = con.Query<Student>(sql, this.SetParameters(oStudent));
                    //if (oStudents != null && oStudents.Count() > 0)
                    //{
                    //    _oStudent = oStudents.FirstOrDefault();
                    //}

                    //Insert by Dapper.Contrib
                    con.Insert(oStudent);
                    _oStudent = oStudent;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _oStudent;
        }

        public Student Update(Student oStudent)
        {
            _oStudent = new Student();
            _oStudent = oStudent;
            oStudent.ModifiedDate = DateTime.Now;
            try
            {
                //int operationType = Convert.ToInt32(oStudent.StudentID == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    // Update by statement of sql
                    //string sql = "update student set StudentID = @StudentID, StudentCode = @StudentCode, StudentName = @StudentName, Birthday = @Birthday, Email = @Email, Address = @Address, ModifiedDate = @ModifiedDate where StudentID = @StudentID";
                    //var oStudents = con.Query<Student>(sql, this.SetParameters(oStudent));
                    //if (oStudents != null && oStudents.Count() > 0)
                    //{
                    //    _oStudent = oStudents.FirstOrDefault();
                    //}

                    // Update by Dapper.Contrib
                    Student oldStudent = con.Get<Student>(oStudent.StudentID);                   
                    _oStudent.CreatedDate = oldStudent.CreatedDate;
                    con.Update<Student>(oStudent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _oStudent;
        }

        private DynamicParameters SetParameters(Student oStudent)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentID", oStudent.StudentID);
            parameters.Add("@StudentCode", oStudent.StudentCode);
            parameters.Add("@StudentName", oStudent.StudentName);
            parameters.Add("@Birthday", oStudent.Birthday);
            parameters.Add("@Email", oStudent.Email);
            parameters.Add("@Address", oStudent.Address);
            parameters.Add("@CreatedDate", oStudent.CreatedDate);
            parameters.Add("@ModifiedDate", oStudent.ModifiedDate);
            return parameters;
        }
    }
}
