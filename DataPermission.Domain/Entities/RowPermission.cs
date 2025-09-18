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
    public class RowPermission: DataPermission, IAggregateRoot
    {
      
        public RowDataScopeEnum DataScopeType { get; private set; }
        public string? ScopeField { get; private set; }
        public string? ScopeValue { get; private set; }      

        private RowPermission() { }
        public RowPermission(string tableName, RowDataScopeEnum dataScopeType, string? scopeField, string? scopeValue,string? description) : base(tableName, description)
        {         
            DataScopeType = dataScopeType;
            ScopeField = scopeField;
            ScopeValue = scopeValue;
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
