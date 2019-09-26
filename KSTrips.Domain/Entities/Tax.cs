using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa Los impuestos
    /// </summary>
    public class Tax
    {
        public int TaxId { get; set; }
        public string Description { get; set; }
        public decimal CostTax { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
