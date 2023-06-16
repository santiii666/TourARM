using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAVCSLib
{
    public interface IGridRowData
    {
        int ColCount();
        String ColCaption(int i);
        String ColData(int i);
        Type ColType(int i);
    }

}
