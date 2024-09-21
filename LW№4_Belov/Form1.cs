using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LW_4_Belov.BuilderBurger;
using LW_4_Belov.DBCon;


namespace LW_4_Belov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            BurgerDirector burgerDirector = new BurgerDirector(burgerBuilder);
            if (comboBox1.SelectedItem.ToString() == "Бургер стандартный")
                burgerDirector.BuildDefault();
            else burgerDirector.BuildBecon();
            try
            {
                model.Burgers.Add(burgerBuilder.GetBurgers());
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }

        private void LoadData()
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = model.Burgers.ToList();
        }
    }
}
