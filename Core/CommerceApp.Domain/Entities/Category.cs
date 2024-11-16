using CommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Domain.Entities
{
    public class Category : EntityBase
    {
        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priority { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
        }

        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
        }
    }
}
