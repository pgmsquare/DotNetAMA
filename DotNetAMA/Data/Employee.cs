using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Data
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public int SortNo { get; set; }

        [Required(ErrorMessage = "이름을 입력하세요.")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "성을 입력하세요.")]
        public string LastName { get; set; }

        [NotMapped]
        public string EmployeeName => FirstName + " " + LastName;

        [Required(ErrorMessage = "직위를 입력하세요.")]
        [Display(Name = "Position")]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "사무실 위치를 입력하세요.")]
        [Display(Name = "Office")]
        public string OfficeLocation { get; set; }

        [Required(ErrorMessage = "나이를 입력하세요.")]
        [Display(Name ="Age")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "시작일자를 입력하세요.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [NotMapped]
        public string StartDateString => StartDate.ToShortDateString();

        [Required(ErrorMessage = "급여를 입력하세요.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [NotMapped]
        public string SalaryString => "$" + Salary.ToString("##,###,###");

        [Required]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
