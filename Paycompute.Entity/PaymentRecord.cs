﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Entity
{
    public class PaymentRecord
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(80)]
        public string FullName { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimeHours  { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings  { get; set; }
        [Column(TypeName = "money")]
        public decimal NationalInsuranceContribution { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> StudentLoanCompany {  get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")]
        public decimal NetPayment { get; set; }
    }
}
