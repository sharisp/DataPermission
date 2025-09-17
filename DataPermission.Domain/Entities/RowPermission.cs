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
    public class RowPermission: BaseEntity, IAggregateRoot
    {
      
        public string TableName { get; private set; }
        public RowDataScopeEnum DataScopeType { get; private set; }
        public string? ScopeField { get; private set; }
        public string? ScopeValue { get; private set; }
        public string? Description { get; set; }

        private RowPermission() { }
        public RowPermission(string tableName, RowDataScopeEnum dataScopeType, string? scopeField, string? scopeValue)
        {
            TableName = tableName;
            DataScopeType = dataScopeType;
            ScopeField = scopeField;
            ScopeValue = scopeValue;
        }

        public void UpdateTableName(string tableName)
        {
            TableName = tableName;
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
