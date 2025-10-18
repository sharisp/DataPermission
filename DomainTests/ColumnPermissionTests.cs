using DataPermission.Domain.Entities;

namespace DomainTests
{
    [Collection("Global Test Collection")]
    public class ColumnPermissionTests
    {
        [Fact]
        public void Test_CreateEntity()
        {
            ColumnPermissionBlackList entity = new ColumnPermissionBlackList("dbo.Users", "Password", "Sensitive column");
            Assert.Equal("dbo.Users", entity.FullTableName);
            Assert.True(entity.Id >0);
        }
        [Fact]
        public void Test_UpdateColumnName()
        {
            ColumnPermissionBlackList entity = new ColumnPermissionBlackList("dbo.Users", "Password", "Sensitive column");
            entity.UpdateColumnName("SSN");
            Assert.Equal("SSN", entity.ColumnName);
        }
        [Fact]
        public void Test_UpdateTableName()
        {
            ColumnPermissionBlackList entity = new ColumnPermissionBlackList("dbo.Users", "Password", "Sensitive column");
            entity.UpdateTableName("dbo.Customers");
            Assert.Equal("dbo.Customers", entity.FullTableName);
        }
        [Fact]
        public void Test_UpdateDescription()
        {
            ColumnPermissionBlackList entity = new ColumnPermissionBlackList("dbo.Users", "Password", "Sensitive column");
            entity.UpdateDescription("Very sensitive column");
            Assert.Equal("Very sensitive column", entity.Description);
        }
    }
}