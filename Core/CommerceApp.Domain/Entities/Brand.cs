using CommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Domain.Entities
{
    public class Brand : EntityBase
    {
        public required string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
        }

        public Brand(string name)
        {
            Name = name;
        }


    }
}
