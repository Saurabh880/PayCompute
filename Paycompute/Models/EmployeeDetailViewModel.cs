﻿using Paycompute.Entity;
using System.ComponentModel.DataAnnotations;

namespace Paycompute.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }
       
        public string EmployeeNo { get; set; }     
       
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
      
        public string Postcode { get; set; }
    }
}
