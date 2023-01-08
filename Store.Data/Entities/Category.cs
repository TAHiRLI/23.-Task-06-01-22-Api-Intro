using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Category:BaseEntity
    {
        /// <summary>
        /// Works!!! 
        /// -How?
        /// -No Idea
        /// </summary>
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
