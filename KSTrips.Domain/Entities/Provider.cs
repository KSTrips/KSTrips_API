using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que representa Las empresas
    /// </summary>
    public class Provider
    {
        public int ProviderId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

 

    }
}
