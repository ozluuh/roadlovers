using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace roadlovers.Models
{
    public class Car
    {
        // Guid.NewGuid().ToString();
        [HiddenInput]
        public int CarId { get; set; }

        [Display(Name = "Ano")]
        public int Year { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Valor")]
        public double Value { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        // [Display(Name = "Classe")]
        public VehicleType VehicleType { get; set; }

        public int VehicleTypeId { get; set; }

        // [Display(Name = "Fabricante")]
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public Car() { }

        public Car(int Year, string Model, double Value, VehicleType VehicleType, Manufacturer Manufacturer)
        {
            this.Year = Year;
            this.Model = Model;
            this.Value = Value;
            this.VehicleType = VehicleType;
            this.Manufacturer = Manufacturer;
        }

        public Car(int Id, int Year, string Model, double Value, VehicleType VehicleType, Manufacturer Manufacturer)
        {
            this.CarId = Id;
            this.Year = Year;
            this.Model = Model;
            this.Value = Value;
            this.VehicleType = VehicleType;
            this.Manufacturer = Manufacturer;
        }
    }

    // public enum VehicleType
    // {
    //     SUV,
    //     [Display(Name = "Utilitário")]
    //     Utilitary,
    //     [Display(Name = "Esportivo")]
    //     Sports,
    //     Muscle,
    //     [Display(Name = "Luxo")]
    //     Luxury,
    //     [Display(Name = "Exótico")]
    //     Exotic,
    //     Tuner
    // }

    // public enum Manufacturer
    // {
    //     Ferrari, Lamborghini, Toyota, Honda, Hyundai, Chevrolet, Gemballa, Nissan,
    //     [Display(Name = "Mercedes-Benz")]
    //     Mercedes_Benz,
    //     Dodge, Hummer, Mitsubishi
    // }
}
