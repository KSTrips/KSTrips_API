using System;
using System.ComponentModel.DataAnnotations;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa Los impuestos
    /// </summary>
    public class Tax : BaseEntity
    {
        public string Description { get; set; }
        public decimal CostTax { get; set; }
    }
}
