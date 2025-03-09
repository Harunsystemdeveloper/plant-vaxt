public class WateringScheduleService
{
    public DateTime CalculateNextWatering(DateTime lastWatered, int daysInterval)
    {
        return lastWatered.AddDays(daysInterval);
    }
}
