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
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private List<Client> list;

        private void FormClient_Load(object sender, EventArgs e)
        {
            list = FileHelper.createListFromFile<Client>("clients");
            GridHelper.List2Grid<Client>(dgv, list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            FormClientEdit fm = new FormClientEdit();
            fm.setObj(obj);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                list.Add(obj);
                FileHelper.saveListToFile<Client>(list, "clients");
                GridHelper.List2Grid<Client>(dgv, list);
            }
        }
    }
}
