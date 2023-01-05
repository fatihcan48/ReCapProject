using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public byte Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public short ModelYear { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
       
    }
}
