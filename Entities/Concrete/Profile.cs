using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Profile:IEntity
    {
        public int UserId { get; set; }
        public byte ProfilePhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

    }
}
