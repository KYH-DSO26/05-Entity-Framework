using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FailSafeRentals.ConsoleApp;

public class Vehicle
{
    public int Id { get; set; }

    [Required, MaxLength(10)]
    public string RegistrationNumber { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Brand { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Model { get; set; } = null!;
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    public List<Rental> Rentals { get; set; } = new();
    public List<ExtraFeatures> ExtraFeatures { get; set; } = new();
}
