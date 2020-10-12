using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DemoDapper.Models
{
    /// <summary>
    /// Sinh viên
    /// Created by: MTHUNG (11/10/2020)
    /// </summary>
    [Table("Student")]
    public class Student
    {
        #region "Constructor"
        public Student()
        {
            StudentID = Guid.NewGuid().ToString();
        }
        #endregion

        #region "Properties"
        /// <summary>
        /// Id sinh viên
        /// </summary>
        [ExplicitKey]
        public string StudentID { get; set; }

        /// <summary>
        /// Mã sinh viên
        /// </summary>
        public string StudentCode { get; set; }

        /// <summary>
        /// Tên sinh viên
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ tạm trú
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày khởi tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày cập nhật bản ghi mới nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        #endregion
    }
}
