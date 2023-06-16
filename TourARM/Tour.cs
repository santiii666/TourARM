using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAVCSLib ;

namespace TourARM
{
    [Serializable]
    public class Tour:BaseClass,IGridRowData
    {
        public string Name;
        public string Len;
        public string Country;
        public int Price;
        public string Valute;

        public Tour()
        {
            Name = "";
            Len = "";
            Country = "";
            Price = 0;
            Valute = "RUR";
        }

        public override string ToString()
        {
            return Name + "(" + Price.ToString("D") + " "+Valute+")";
        }

                // grid
        public int ColCount()
        {
            return 5;
        }
        public String ColCaption(int i)
        {
            if (i == 0) return "Название";
            if (i == 1) return "Длительность";
            if (i == 2) return "Страна";
            if (i == 3) return "Цена";
            if (i == 4) return "Валюта";
            return "";
        }
        public String ColData(int i)
        {
            if (i == 0) return Name;
            if (i == 1) return Len;
            if (i == 2) return Country;
            if (i == 3) return Price.ToString("D");
            if (i == 4) return Valute;
            return "";
        }
        public Type ColType(int i)
        {
            if (i == 3) return typeof(int);
            return typeof(string);
        }

    }
}
