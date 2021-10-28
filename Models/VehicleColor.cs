using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace roadlovers.Models
{
    [Table("Tbl_Vehicle_Color")]
    public class VehicleColor
    {
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
    }
}