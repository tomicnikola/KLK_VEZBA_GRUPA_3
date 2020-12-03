using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayerWeb
{
    public partial class _Default : Page
    {
        private VetBusiness vetBusiness;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            this.vetBusiness = new VetBusiness();
            RefreshData();
        }
        public void RefreshData()
        {
            List<Vet> v = this.vetBusiness.GetAllVets();
            listBoxVets.Items.Clear();

            foreach (Vet vets in v)
                listBoxVets.Items.Add(vets.Id + ". " + vets.FullName + "- " + vets.Specialty + "- " + vets.YearsExperience);
        }
    }
}