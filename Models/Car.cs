using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace roadlovers.Models
{
    [Table("Tbl_Cars")]
    public class Car
    {
        [Column("Id"), HiddenInput]
        public int CarId { get; set; }

        [Display(Name = "Ano")]
        public int Year { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Valor")]
        public double Value { get; set; }

        [Column("Created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        // N : 1
        [Display(Name = "Classe")]
        public VehicleType VehicleType { get; set; }

        public int? VehicleTypeId { get; set; }

        // N : 1
        [Display(Name = "Fabricante")]
        public Manufacturer Manufacturer { get; set; }
        public int? ManufacturerId { get; set; }

        // N : M
        public ICollection<VehicleColor> VehiclesColors { get; set; }

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
}
