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
    public partial class FormTourEdit : Form
    {
        public FormTourEdit()
        {
            InitializeComponent();
        }

        private Tour obj;

        public void setObj(Tour Aobj)
        {
            obj = Aobj;
            GUIHelper.string2Combo(FormRef.loadRef("country"), comboCountry, obj.Country);
            GUIHelper.string2Combo(FormRef.loadRef("valutes"), comboValute, obj.Valute);
            ObjEditor.Obj2Form(this, obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string country = "" ;
            string valute = "" ;

            if (!GUIHelper.getFromCombo(comboCountry, ref country))
            {
                MessageBox.Show("Не выбрана страна"); return;
            }

            if (!GUIHelper.getFromCombo(comboValute, ref valute))
            {
                MessageBox.Show("Не выбрана валюта"); return;
            }

            obj.Valute = valute;
            obj.Country = country;
            ObjEditor.Form2Obj(this, obj);

            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
