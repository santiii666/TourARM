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
    public partial class FormSell : Form
    {
        public FormSell()
        {
            InitializeComponent();
        }

        private List<Sell> list;

        private void FormSell_Load(object sender, EventArgs e)
        {
            list = FileHelper.createListFromFile<Sell>("sells");
            GridHelper.List2Grid<Sell>(dgv, list);

            GUIHelper.list2Combo(FileHelper.createListFromFile<Tour>("tours"), comboTour,null);
            GUIHelper.list2Combo(FileHelper.createListFromFile<Client>("clients"), comboClient,null);

            textLen.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sell sell = new Sell();

            Tour tour = null;
            Client client = null;

            if (!GUIHelper.getFromCombo(comboTour, ref tour))
            {
                MessageBox.Show("Не выбран тур"); return;
            }

            if (!GUIHelper.getFromCombo(comboClient, ref client))
            {
                MessageBox.Show("Не выбран клиент"); return;
            }

            sell.tour = tour;
            sell.client = client;
            sell.DateSell = textLen.Text;
            list.Add(sell);
            FileHelper.saveListToFile<Sell>(list, "sells");
            GridHelper.List2Grid<Sell>(dgv, list);

        }
    }
}
