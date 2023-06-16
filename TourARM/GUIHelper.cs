using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAVCSLib
{
    class GUIHelper
    {

        public static void list2Combo<T>(List<T> list, ComboBox combo, T selected)
        {
            combo.Items.Clear() ;
            for (int i = 0; i < list.Count; i++)
            {
                combo.Items.Add(list[i]);
                if (selected!=null)
                    if (list[i].Equals(selected)) combo.SelectedIndex = i;
            }
        }

        public static void string2Combo(List<String> list, ComboBox combo, String selected = "") 
        {
            combo.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                combo.Items.Add(list[i]);
                if (list[i].Equals(selected)) combo.SelectedIndex = i;
            }
        }

	    public static bool getFromCombo<T>(ComboBox combo, ref T sel) {
	        if (combo.SelectedIndex == -1) return false ; else {
		        sel = (T)combo.Items[combo.SelectedIndex] ;
		        return true ;
	        }
	    }
        public static bool retFalse(string str)
        {
            MessageBox.Show(str);
            return false;
        }

    }
}
