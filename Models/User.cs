using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace passholder.Models
{
    public class User : BaseModel
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public UserLogin Login { get; set; }
        public List<UserCred> UserCred { get; set; }
    }

    public class UserLogin : BaseModel
    {
        public Guid UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoginDate { get; set; }

        [StringLength(10)]
        public string OTP { get; set; }

        [DataType(DataType.Date)]
        public DateTime OTPCreatedDate { get; set; }
        public string LocationIP { get; set; }
    }
}
