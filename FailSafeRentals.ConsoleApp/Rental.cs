namespace FailSafeRentals.ConsoleApp;

public class Rental
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } // Nullable tills bilen återlämnas
    public decimal TotalCost { get; set; }

    // Främmande nycklar enligt vår standard (<Tabellnamn>Id)
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}