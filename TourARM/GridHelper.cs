using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TAVCSLib
{
    class GridHelper
    {
        public static void List2Grid<T>(DataGridView dgv, List<T> list) where T : IGridRowData
        {
            // Старая схема, тупит при большом количестве
            /*
             dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.RowHeadersWidth = 30;

            if (list.Count == 0) return;

            for (int j = 0; j < list[0].ColCount(); j++)
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn());
                dgv.Columns[j].HeaderCell.Value = list[0].ColCaption(j);
            }

            for (int i = 0; i < list.Count(); i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dgv.Rows[i].HeaderCell.Tag = list[i];
                for (int j = 0; j < list[i].ColCount(); j++)
                    dgv.Rows[i].Cells[j].Value = list[i].ColData(j);
            }
             */

            dgv.RowHeadersWidth = 30;

            if (list.Count == 0)
            {
                dgv.Hide();
                return;
            }
            dgv.Show();

            DataTable dt = new DataTable();
            for (int j = 0; j < list[0].ColCount(); j++)
            dt.Columns.Add(new DataColumn(list[0].ColCaption(j),list[0].ColType(j))) ;
            dt.Columns.Add(new DataColumn("O", typeof(T)));
            
            for (int i = 0; i < list.Count(); i++) {
                DataRow row = dt.NewRow() ;
                for (int j = 0; j < list[0].ColCount(); j++)
                    row[list[0].ColCaption(j)] = list[i].ColData(j);
                row["O"] = list[i];
                dt.Rows.Add(row) ;
            }

            dgv.DataSource = dt ;
            dgv.Columns[list[0].ColCount()].Visible = false;


        }

        public static object getObj(DataGridView dgv) {
            // От старой схемы
            //return dgv.CurrentCell.OwningRow.HeaderCell.Tag;
            if (dgv.CurrentRow == null) return null;
            return (dgv.CurrentRow.DataBoundItem as DataRowView).Row["O"];
        }

        public static void updateTekObj(DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return ;
            DataRow row = (dgv.CurrentRow.DataBoundItem as DataRowView).Row ;
            IGridRowData grd = (IGridRowData)getObj(dgv) ;

            for (int j = 0; j < grd.ColCount(); j++)
                row[grd.ColCaption(j)] = grd.ColData(j);
        }

    }
}
