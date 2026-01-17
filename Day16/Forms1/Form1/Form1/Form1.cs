using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string FileName = ofd.FileName;
            Assembly assemblyObj = Assembly.LoadFrom(FileName);
            Type[] myType = assemblyObj.GetTypes();
            this.ReflectAll(myType[0]);




        }

        private void ReflectAll(Type type)
        {
            MethodInfo[] methodList = type.GetMethods();
            PropertyInfo[] propList = type.GetProperties();

            foreach (var item in propList)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
