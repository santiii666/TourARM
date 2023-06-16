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
    public partial class FormTour : Form
    {
        public FormTour()
        {
            InitializeComponent();
        }

        private List<Tour> list;

        private void FormTour_Load(object sender, EventArgs e)
        {
            list = FileHelper.createListFromFile<Tour>("tours");
            GridHelper.List2Grid<Tour>(dgv, list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tour obj = new Tour();
            FormTourEdit fm = new FormTourEdit();
            fm.setObj(obj);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                list.Add(obj);
                FileHelper.saveListToFile<Tour>(list, "tours");
                GridHelper.List2Grid<Tour>(dgv, list);
            }
        }
    }
}
