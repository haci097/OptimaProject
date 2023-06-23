using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Concrete
{
    public class Discount : IEntity
    {
        public int Id { get; set; }
        [Required]
        public byte DiscountAmount { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

    }
}
