namespace OperationOOP.Core.Models
{
    public class Plant
    {
        public int Id { get; set; }  // Växtens ID
        public string Name { get; set; } // Växtens Namn
        public string Species { get; set; } // Art eller sort på växten
        public string CareLevel { get; set; } // T.ex. låg, medel, hög
    }
}
