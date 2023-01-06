using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public byte CarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }

        public CarImage()
        {
            Date = DateTime.Now;
        }
    }
}
