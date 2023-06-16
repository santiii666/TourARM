using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TourARM
{
    public partial class FormRef : Form
    {
        public FormRef()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveRef();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private string FileName;

        public static List<String> loadRef(string AFileName)
        {
            List<String> list = new List<String>();
            if (File.Exists(AFileName))
            {
                StreamReader stm = new StreamReader(AFileName);
                try
                {
                    String line;
                    while ((line = stm.ReadLine()) != null)
                        if (line.Trim().Length > 0)
                            list.Add(line);
                }
                finally
                {
                    stm.Close();
                }
            }
            list.Sort();
            return list;
        }

        public void initRef(string AFileName, string RefName)
        {
            FileName=AFileName ;
            Text = RefName;
            textData.Clear() ;
            if (File.Exists(FileName)) {
            StreamReader stm = new StreamReader(FileName);
            try
            {
                String line;
                while ((line = stm.ReadLine()) != null)
                    if (line.Trim().Length > 0)
                        textData.AppendText(line+Environment.NewLine) ;
            }
            finally
            {
                stm.Close();
            }
            }

        }

        private void saveRef()
        {
            StreamWriter stm = new StreamWriter(FileName, false);
            try
            {
                stm.WriteLine(textData.Text);
            }
            finally
            {
                stm.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}
