using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VetBusiness
    {
        private readonly VetRepository vetRepository;

        public VetBusiness()
        {
            this.vetRepository = new VetRepository();

        }

        public List<Vet> GetAllVets()
        {
            return this.vetRepository.GetAllVets();
        }

        public bool InsertVet(Vet v)
        {
            if (this.vetRepository.InsertVet(v) > 0)
                return true;
            return false;
        }
        public bool UpdateVet(Vet v,int id)
        {
            if (this.vetRepository.UpdateVet(v,id) > 0)
                return true;
            return false;
        }
        public bool DeleteVet(int id)
        {        
            if (this.vetRepository.DeleteVet(id) > 0)
                return true;
            return false;           
        }

        public List<Vet> GetAllVetsGTYE(int yoe)
        {
            return this.vetRepository.GetAllVets().Where(v => v.YearsExperience > yoe).ToList();
        }
    }
}
