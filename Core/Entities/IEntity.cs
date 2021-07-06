using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    //IEntity implemente eden class bir veritabanı tablosuna karşılık gelmektedir.
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        string CreatedUser { get; set; }
        string ModifiedUser { get; set; }
    }
}
