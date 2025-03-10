using System;

namespace OperationOOP.Core.Services
{
    public class WateringScheduleService
    {
        public DateTime CalculateNextWatering(DateTime lastWatering, int intervalDays) // Detta talar om för oss när nästa tillfälle för bevattning är
        {
            return lastWatering.AddDays(intervalDays); // Detta lägger till dagar till senaste vattning
        }
    }
}

