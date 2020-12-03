using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {

        private readonly VetBusiness vetBusiness;
        public Form1()
        {
            this.vetBusiness = new VetBusiness();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();

        }

        public void RefreshData()
        {
            List<Vet> v = this.vetBusiness.GetAllVets();
            listBoxVets.Items.Clear();

            foreach (Vet vets in v)
                listBoxVets.Items.Add(vets.Id + ". " + vets.FullName + "- " + vets.Specialty + "- " + vets.YearsExperience);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string v = listBoxVets.SelectedItem.ToString();
            var temp = Convert.ToInt32(v.Split('.')[0]);
            Vet vet = new Vet();
            vet.FullName = textBox1.Text;
            vet.Specialty = textBox2.Text;
            vet.YearsExperience = Convert.ToInt32(textBox3.Text);

            if(this.vetBusiness.UpdateVet(vet, temp))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("Greska");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vet vet = new Vet();
            vet.FullName = textBox1.Text;
            vet.Specialty = textBox2.Text;
            vet.YearsExperience = Convert.ToInt32(textBox3.Text);

            if(this.vetBusiness.InsertVet(vet))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Greska");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int yoe = Convert.ToInt32(textBox4.Text);
            List<Vet> vets = this.vetBusiness.GetAllVetsGTYE(yoe);

            if(this.vetBusiness.GetAllVetsGTYE(yoe).Count > 0)
            {
                foreach (Vet v in vets)
                    listBox1.Items.Add(v.Id + ". " + v.FullName + "- " + v.Specialty + "- " + v.YearsExperience);
               

            }
            else
            {
                MessageBox.Show("Ne postoji vet sa vise godina iskustva");
            }
            textBox4.Text = "";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string v = listBoxVets.SelectedItem.ToString();
            var temp = Convert.ToInt32(v.Split('.')[0]);
          
            if (this.vetBusiness.DeleteVet(temp))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("Greska");
            }
        }
    }
}
