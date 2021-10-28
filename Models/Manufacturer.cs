using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace roadlovers.Models
{
    [Table("Tbl_Manufacturers")]
    public class Manufacturer
{
    [Column("Id"), HiddenInput]
    public int ManufacturerId { get; set; }

    public string Name { get; set; }
}
}