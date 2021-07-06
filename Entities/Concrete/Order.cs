using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("Tb_Order")]
    public class Order : IEntity
    {
        [Key] public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
    }
}
