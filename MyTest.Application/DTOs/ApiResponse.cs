using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Application.DTOs
{
    public class LifeSpan
    {
        public int Max { get; set; }
        public int Min { get; set; }
    }

    public class Weight
    {
        public int Max { get; set; }
        public int Min { get; set; }
    }

    public class Attributes
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LifeSpan Life { get; set; }
        public Weight Male_Weight { get; set; }
        public Weight Female_Weight { get; set; }
        public bool Hypoallergenic { get; set; }
    }

    public class Relationships
    {
        public Group Group { get; set; }
    }

    public class Group
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class Breed
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Attributes Attributes { get; set; }
        public Relationships Relationships { get; set; }
    }

    public class ApiResponse
    {
        public List<Breed> Data { get; set; }
        public Links Links { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
    }

}
