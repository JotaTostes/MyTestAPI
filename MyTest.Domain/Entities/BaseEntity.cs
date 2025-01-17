using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Application.Entities
{
    public abstract class BaseEntity<TAttributes>
    {
        public string Id { get; set; }          
        public string Type { get; set; }        
        public TAttributes Attributes { get; set; } 
    }

    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; }      
        public PaginationLinks Links { get; set; } 
    }

    public class PaginationLinks
    {
        public string Self { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
        public string Last { get; set; }
    }
}
