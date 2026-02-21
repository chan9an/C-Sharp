using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIsconnectedArchi
{
    public partial class Form1 : Form
    {
        IRepo<Product> repo;
        public Form1()
        {
            InitializeComponent();
            repo = new ProductUtility();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.ShowAll();   // connected (your old test)

            ProductUtility pUtil = new ProductUtility();
            DataTable myDt = pUtil.GetAllData();          // disconnected

            //bind textbox1(Product ID)
            //textBox1.DataBindings.Clear();
            //textBox1.DataBindings.Add("Text", myDt, "ProdID");

            //bind textbox2(Name)
            //textBox2.DataBindings.Clear();
            //textBox2.DataBindings.Add("Text", myDt, "Name");

            //bind textbox3(Price)
            //textBox3.DataBindings.Clear();
            //textBox3.DataBindings.Add("Text", myDt, "Price");

            //bind textbox4(Description)
            //textBox4.DataBindings.Clear();
            //textBox4.DataBindings.Add("Text", myDt, "Desc");



        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnShowProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
