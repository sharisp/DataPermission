using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Enums
{
    public enum RowDataDenyOperateEnum
    {
        NoRead = 0,
        NoEdit = 1,
        NoDelete = 2,
        NoEditAndDelete = 3,
    }
}
