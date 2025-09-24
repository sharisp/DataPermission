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
    public class RowPermissionList : DataPermissionList, IAggregateRoot
    {

        public RowDataScopeEnum DataScopeType { get; private set; }
        public string? ScopeField { get; private set; }
        public string? ScopeValue { get; private set; }
        public RowDataAllowOperateEnum RowDataAllowOperateType { get; set; } = RowDataAllowOperateEnum.All;

        private RowPermissionList() { }
        public RowPermissionList(string fullTableName, RowDataScopeEnum dataScopeType, RowDataAllowOperateEnum rowDataAllowOperateType, string? scopeField, string? scopeValue, string? description) : base(fullTableName, description)
        {
            DataScopeType = dataScopeType;
            ScopeField = scopeField;
            ScopeValue = scopeValue;
            RowDataAllowOperateType = rowDataAllowOperateType;
        }

        public void UpdateRowDataOperateType(RowDataAllowOperateEnum rowDataAllowOperateType)
        {
            RowDataAllowOperateType = rowDataAllowOperateType;
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
