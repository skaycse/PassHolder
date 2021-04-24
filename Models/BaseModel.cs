using System;
using System.ComponentModel.DataAnnotations;

namespace passholder.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}
