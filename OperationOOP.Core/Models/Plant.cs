public class Plant : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string CareLevel { get; set; } // T.ex. låg, medel, hög
}
