using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tb_Product : IEntity
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
