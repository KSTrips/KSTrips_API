using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa Los impuestos
    /// </summary>
    public class Tax : BaseEntity
    {
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal CostTax { get; set; }
    }
}
