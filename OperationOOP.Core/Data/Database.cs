using OperationOOP.Core.Models;
namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<Plant> Plants { get; set; } // Lägg till Plants listan här för att hantera plantorna.
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<Plant> Plants { get; set; } = new List<Plant>(); // Lägg till Plants lista här.
    }
}

