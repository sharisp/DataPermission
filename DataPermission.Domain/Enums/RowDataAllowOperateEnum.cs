using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Enums
{
    [Flags]
    public enum RowDataAllowOperateEnum
    {
        Read = 1,
        Edit = 2,
        Delete = 4,
        All = Read | Edit | Delete
    }
   
}
