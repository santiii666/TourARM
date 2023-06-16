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
    public partial class FormClientEdit : Form
    {
        public FormClientEdit()
        {
            InitializeComponent();
        }

        private Client obj;

        public void setObj(Client Aobj)
        {
            obj = Aobj;
            ObjEditor.Obj2Form(this, obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjEditor.Form2Obj(this, obj);

            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
