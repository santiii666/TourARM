using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAVCSLib;

namespace TourARM
{
    [Serializable]
    public class Sell : BaseClass, IGridRowData
    {
        public Client client;
        public Tour tour;
        public string DateSell;

        public Sell()
        {
            DateSell = DateTime.Now.ToShortDateString();
        }
        
        // grid
        public int ColCount()
        {
            return 3;
        }
        public String ColCaption(int i)
        {
            if (i == 0) return "Тур";
            if (i == 1) return "Клиент";
            if (i == 2) return "Дата";
            return "";
        }
        public String ColData(int i)
        {
            if (i == 0) return client.ToString();
            if (i == 1) return tour.ToString();
            if (i == 2) return DateSell;
            return "";
        }
        public Type ColType(int i)
        {
            return typeof(string);
        }

    }
}
