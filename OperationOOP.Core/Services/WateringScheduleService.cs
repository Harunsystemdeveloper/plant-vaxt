using System;

namespace OperationOOP.Core.Services
{
    public class WateringScheduleService
    {
        public DateTime CalculateNextWatering(DateTime lastWatering, int intervalDays)
        {
            return lastWatering.AddDays(intervalDays);
        }
    }
}

