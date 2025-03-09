public class PlantFilterService
{
    public List<Plant> FilterPlantsByCareLevel(List<Plant> plants, string careLevel)
    {
        return plants.Where(p => p.CareLevel.Equals(careLevel, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
