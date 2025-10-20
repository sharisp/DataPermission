using DataPermission.Domain.Interfaces;
using DataPermission.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests
{

    [Collection("Global Test Collection")]
    public class RowPermissionServiceTest
    {
        private readonly Mock<IRowDataPermissionRepository> _rowPermisionRespMock;
        private readonly RowPermissionService _rowPermissionService;

        public RowPermissionServiceTest()
        {
            _rowPermisionRespMock = new Mock<IRowDataPermissionRepository>();
            _rowPermissionService = new RowPermissionService(_rowPermisionRespMock.Object);
        }
        [Fact]
        public async void Test_ExistsDeptWithoutIdConflictAsync_Fail()
        {
            _rowPermisionRespMock.Setup( x => x.ExistsConflictAsync("TableA",DataPermission.Domain.Enums.RowDataScopeEnum.Department,null,null,null)).ReturnsAsync(false);
            var result = await _rowPermissionService.ExistsConflictAsync("TableA", DataPermission.Domain.Enums.RowDataScopeEnum.Department, null, null, null);
            Assert.False(result);
        }
        [Fact]
        public async void Test_ExistsDeptWithoutIdConflictAsync_Success()
        {
            _rowPermisionRespMock.Setup(x => x.ExistsConflictAsync("TableA", DataPermission.Domain.Enums.RowDataScopeEnum.Department, null, null, null)).ReturnsAsync(true);
            var result = await _rowPermissionService.ExistsConflictAsync("TableA", DataPermission.Domain.Enums.RowDataScopeEnum.Department, null, null, null);
            Assert.True(result);
        }
        [Fact]
        public async void Test_ExistsPersonWithoutIdConflictAsync_Success()
        {
            _rowPermisionRespMock.Setup(x => x.ExistsConflictAsync("TableA", DataPermission.Domain.Enums.RowDataScopeEnum.Personal, null, null, null)).ReturnsAsync(true);
            var result = await _rowPermissionService.ExistsConflictAsync("TableA", DataPermission.Domain.Enums.RowDataScopeEnum.Personal, null, null, null);
            Assert.True(result);
        }

    }
}
