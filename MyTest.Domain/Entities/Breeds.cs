using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Application.Entities
{

    public class Breed
    {
        public Guid Id { get; set; } // Chave primária
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Hypoallergenic { get; set; }
        public int FemaleWeightMin { get; set; }
        public int FemaleWeightMax { get; set; }
        public int MaleWeightMin { get; set; }
        public int MaleWeightMax { get; set; }
        public int LifeMin { get; set; }
        public int LifeMax { get; set; }
    }
    
}
