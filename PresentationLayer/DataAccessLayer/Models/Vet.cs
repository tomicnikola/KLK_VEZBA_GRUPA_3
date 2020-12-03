using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Vet
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public int YearsExperience { get; set; }

        public override string ToString()
        {
            return Id + ". " + FullName + "- " + Specialty + "- " + YearsExperience;
        }
    }
}
