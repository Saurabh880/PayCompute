using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paycompute.Entity
{
    public class TaxYear
    {
        [Key]
        public int TaxId { get; set; }
        public string YearOfTax { get; set; }
    }
}
