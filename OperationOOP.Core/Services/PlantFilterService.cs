using System.Collections.Generic;
using System.Linq;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services
{
    public class PlantFilterService
    {
        public List<Plant> FilterPlantsByCareLevel(List<Plant> plants, string careLevel)
        {
            return plants.Where(p => p.CareLevel.ToLower() == careLevel.ToLower()).ToList();
        }
    }
}

