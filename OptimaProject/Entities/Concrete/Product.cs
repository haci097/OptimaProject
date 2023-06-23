using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public bool Status { get; set; }

    }
}
