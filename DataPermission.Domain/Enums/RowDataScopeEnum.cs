using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Enums
{
    public enum RowDataScopeEnum
    {
        None = 0,
        Personal = 1,
        Department = 2,
        DepartmentAndSubordinates = 3,        
        Custom = 4,
    }
}
