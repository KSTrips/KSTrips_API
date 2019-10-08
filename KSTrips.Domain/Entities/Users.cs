using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class Users
    {

        public int UserId { get; set; }
        public string AuthZero_Id { get; set; }
        public string Given_Name { get; set; }
        public string Family_Name { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
