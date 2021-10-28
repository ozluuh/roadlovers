using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace roadlovers.Models
{
    [Table("Tbl_Classes")]
    public class VehicleType
    {

        [Column("Id"), HiddenInput]
        public int VehicleTypeId { get; set; }

        public string Description { get; set; }

        // 1 : N
        public virtual ICollection<Car> cars { get; set; }
    }
}