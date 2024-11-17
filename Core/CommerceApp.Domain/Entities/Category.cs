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
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

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
