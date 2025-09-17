using DataPermission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Interfaces
{
    public interface IRowPermission
    {
        Task AddRowPermission(RowPermission rowPermission);
        Task DeleteRowPermission(long id);
    }
}
