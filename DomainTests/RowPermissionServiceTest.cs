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
        public void Test_ExistsConflictAsync_Fail()
        {
        
        }
    }
}
