using System;
using System.Collections.Generic;
using System.Text;

namespace FailSafeRentals.ConsoleApp;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DriverLicenseNumber { get; set; } = null!;
    public List<Rental> Rentals { get; set; } = new();
}
