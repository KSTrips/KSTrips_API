using KSTrips.Domain.Transversal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Application.Interfaces
{
    public interface IHomeService
    {
        Video GetPromotionalVideo();

        Video GetHowUseAppVideo();
    }
}
