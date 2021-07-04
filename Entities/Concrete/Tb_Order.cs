using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Tb_Order : IEntity
    {
        [Key] public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderAdress { get; set; }
    }
}
