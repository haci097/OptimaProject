using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Concrete
{
    public class Detail : IEntity
    {
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
