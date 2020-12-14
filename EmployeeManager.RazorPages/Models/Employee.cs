using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.RazorPages.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Employee ID is required")]
        [Display(Name ="Employee ID")]
        public int EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(20,ErrorMessage ="First Name must be less than 20 characters")]
        [Required(ErrorMessage = "Employee First Name is required")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last Name must be less than 30 characters")]
        [Required(ErrorMessage = "Employee Last Name is required")]
        public string LastName { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Column("HireDate")]
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }

        [Column("Country")]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

    }
}
