﻿using Paycompute.Entity;
using System.ComponentModel.DataAnnotations;

namespace Paycompute.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee Number is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]$")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage ="First name is required"),StringLength(50, MinimumLength = 5)]
        [RegularExpression (@"^[A-Z][a-zA-Z""'\s-]*$"),Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50),Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required"), StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName { get {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ".").ToUpper()) + LastName ;
            } }
        public string Gender { get; set; }
        [Display(Name = "Photo  ")]
        public IFormFile ImageURL { get; set; }
        [DataType(DataType.Date) , Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of Joined")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;  
        [Required (ErrorMessage ="Job Role is required"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }
        [Required(ErrorMessage ="Phone number is required"), Display(Name = "Mobile Number")]
        public  string Phone { get; set; }
        [Required, StringLength(50),Display(Name = "NI No.")]
        [RegularExpression(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9][A-D\s]$")]
        public string NationalInsuranceNo { get; set; }
        [Display(Name= "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Method")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Method")]
        public UnionMember UnionMember { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(10)]
        public string Postcode { get; set; }
    }
}
