using System.Collections.Generic;
using System.Linq;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services
{
    public class PlantFilterService
    {
        
        public List<Plant> FilterPlantsByCareLevel(List<Plant> plants, string careLevel)
        {
            // Detta returnerar växter med samma behov utav vård.
            return plants
                .Where(p => p.CareLevel.ToLower() == careLevel.ToLower())
                .ToList();
        }

        // Här vi filtrerar vi växter utifrån art
        public List<Plant> FilterPlantsBySpecies(List<Plant> plants, string species)
        {
            // Detta returnerar växter med liknande art till oss
            return plants 
                .Where(p => p.Species.ToLower() == species.ToLower())
                .ToList();
        }
    }
}


