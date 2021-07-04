using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto:IDto
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
