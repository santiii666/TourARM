using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAVCSLib ;

namespace TourARM
{
    [Serializable]
    public class Client: BaseClass, IGridRowData
    {
        public string FIO;
        public string Phone;
        public string Info;
        
        public Client()
        {
            FIO = "";
            Phone = "";
            Info = "";
        }

        public override string ToString()
        {
            return FIO;
        }

        // grid
        public int ColCount()
        {
            return 3;
        }
        public String ColCaption(int i)
        {
            if (i == 0) return "ФИО";
            if (i == 1) return "Контакт";
            if (i == 2) return "Заказ";
            return "";
        }
        public String ColData(int i)
        {
            if (i == 0) return FIO;
            if (i == 1) return Phone;
            if (i == 2) return Info;
            return "";
        }
        public Type ColType(int i)
        {
            return typeof(string);
        }

    }
}
