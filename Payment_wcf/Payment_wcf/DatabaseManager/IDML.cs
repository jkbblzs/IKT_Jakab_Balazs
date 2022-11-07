using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_wcf;

namespace Payment_wcf.DatabaseManager
{
    internal interface IDML
    {
        int Insert(Customer record);

        int Update(Customer record);

        int Delete(int id);
    }
}
