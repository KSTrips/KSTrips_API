﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
   public interface IVehicleService
   {

       Task<List<Vehicle>> GetVehiclesByUser(string authZeroId);
        bool SaveVehicles(IEnumerable<InComingVehicles> vehicles);
        bool UpdateVehicles(IEnumerable<InComingVehicles> vehicles);
    }
}