using DataPermission.Domain.Enums;
using Domain.SharedKernel.BaseEntity;
using Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Domain.Entities
{
    public class RowPermissionBlackList : DataPermissionBlackList, IAggregateRoot
    {

        public RowDataScopeEnum DataScopeType { get; private set; }
        public string? ScopeField { get; private set; }
        public string? ScopeValue { get; private set; }
        public RowDataDenyOperateEnum RowDataDenyOperateType { get; set; } = RowDataDenyOperateEnum.NoRead;

        private RowPermissionBlackList() { }
        public RowPermissionBlackList(string fullTableName, RowDataScopeEnum dataScopeType, RowDataDenyOperateEnum rowDataDenyOperateType, string? scopeField, string? scopeValue, string? description) : base(fullTableName, description)
        {
            DataScopeType = dataScopeType;
            ScopeField = scopeField;
            ScopeValue = scopeValue;
            RowDataDenyOperateType = rowDataDenyOperateType;
        }

        public void UpdateRowDataOperateType(RowDataDenyOperateEnum rowDataDenyOperateType)
        {
            RowDataDenyOperateType = rowDataDenyOperateType;
        }
        public void UpdateDataScopeType(RowDataScopeEnum dataScopeType)
        {
            DataScopeType = dataScopeType;
        }
        public void UpdateScopeField(string? scopeField)
        {
            ScopeField = scopeField;
        }
        public void UpdateScopeValue(string? scopeValue)
        {
            ScopeValue = scopeValue;
        }

    }
}
