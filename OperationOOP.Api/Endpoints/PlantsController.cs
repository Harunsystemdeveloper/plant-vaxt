using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Models;
using OperationOOP.Core.Services;
using System.Collections.Generic;

namespace OperationOOP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly PlantFilterService _plantFilterService;
        private readonly WateringScheduleService _wateringScheduleService;
        
    
        private static List<Plant> plants = new List<Plant>
        {
            new Plant { Id = 1, Name = "Bonsai Tree", Species = "Ficus", CareLevel = "High" },
            new Plant { Id = 2, Name = "Cactus", Species = "Cactaceae", CareLevel = "Low" }
        };

        public PlantsController(PlantFilterService plantFilterService, WateringScheduleService wateringScheduleService)
        {
            _plantFilterService = plantFilterService;
            _wateringScheduleService = wateringScheduleService;
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Plant>> GetPlants()
        {
            return Ok(plants);
        }

       
        [HttpGet("{id}")]
        public ActionResult<Plant> GetPlant(int id)
        {
            var plant = plants.Find(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        
        [HttpGet("care-level/{level}")]
        public ActionResult<IEnumerable<Plant>> GetPlantsByCareLevel(string level)
        {
            var filteredPlants = _plantFilterService.FilterPlantsByCareLevel(plants, level);
            return Ok(filteredPlants);
        }

        
        [HttpPost]
        public ActionResult<Plant> CreatePlant(Plant newPlant)
        {
            newPlant.Id = plants.Count + 1; 
            plants.Add(newPlant);
            return CreatedAtAction(nameof(GetPlant), new { id = newPlant.Id }, newPlant);
        }

    
        [HttpPut("{id}")]
        public ActionResult UpdatePlant(int id, Plant updatedPlant)
        {
            var plant = plants.Find(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            plant.Name = updatedPlant.Name;
            plant.Species = updatedPlant.Species;
            plant.CareLevel = updatedPlant.CareLevel;

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            var plant = plants.Find(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            plants.Remove(plant);
            return NoContent();
        }
    }
}
