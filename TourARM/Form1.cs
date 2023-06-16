using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAVCSLib;

namespace TourARM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRef fm = new FormRef();
            fm.initRef("country", "Страны");
            fm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRef fm = new FormRef();
            fm.initRef("users", "Сотрудники");
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRef fm = new FormRef();
            fm.initRef("valutes", "Валюты");
            fm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormTour fm = new FormTour();
            fm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormValute fm = new FormValute();
            fm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormClient fm = new FormClient();
            fm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormSell fm = new FormSell();
            fm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string res = "Сводка по турам" + Environment.NewLine + Environment.NewLine;

            List<Sell> list = FileHelper.createListFromFile<Sell>("sells");
                        
            foreach (Tour item in FileHelper.createListFromFile<Tour>("tours"))
            {
                
                int sum = list.Where( (s) => s.tour.Name.Equals(item.Name)).Sum( (s) => s.tour.Price ) ;
                res += (item.Name + ": "+sum.ToString("D")+ Environment.NewLine);
            }
            MessageBox.Show(res);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string res = "Сводка по клиентам" + Environment.NewLine + Environment.NewLine;

            List<Sell> list = FileHelper.createListFromFile<Sell>("sells");

            foreach (Client item in FileHelper.createListFromFile<Client>("clients"))
            {

                int sum = list.Where((s) => s.client.FIO.Equals(item.FIO)).Sum((s) => s.tour.Price);
                res += (item.FIO + ": " + sum.ToString("D") + Environment.NewLine);
            }
            MessageBox.Show(res);
        }
    }
}
