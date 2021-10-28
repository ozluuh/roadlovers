using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace roadlovers.Models
{
    [Table("Tbl_Color")]
    public class Color
    {
        [Column("Id"), HiddenInput]
        public int ColorId { get; set; }

        public string Name { get; set; }

        // M : N
        public ICollection<VehicleColor> VehiclesColors { get; set; }
    }
}