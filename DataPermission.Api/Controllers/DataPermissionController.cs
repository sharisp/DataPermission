using DataPermission.Api.Attributes;
using DataPermission.Api.Contracts.Dtos.Request;
using DataPermission.Api.Contracts.Dtos.Response;
using DataPermission.Domain.Enums;
using DataPermission.Domain.Interfaces;
using DataPermission.Domain.Services;
using DataPermission.Infra.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DataPermissionController(IColumnDataPermissionRepository columnPermissionRepository, IRowDataPermissionRepository rowPermissionRepository, RoleDataPermissionService domainService) : ControllerBase
    {
        [PermissionKey("DataPermission.List")]
        [HttpGet("{roleId}")]
        public async Task<ActionResult<ApiResponse<DataResponseDto>>> GetDataPermissionsByRoleId(long roleId)
        {
            var columnPermissions = await columnPermissionRepository.GetAllByRoleId(roleId);
            var rowPermissions = await rowPermissionRepository.GetAllByRoleId(roleId);

            return this.OkResponse(new DataResponseDto(rowPermissions, columnPermissions));
        }

        [PermissionKey("DataPermission.RowPermission")]
        [HttpPost("RowDataPermission/{roleId}")]
        public async Task<ActionResult<ApiResponse<DataResponseDto>>> SetRowDataPermission(long roleId, [FromBody] PermissionIdsDto dto)
        {
            await domainService.SetRoleDataPermission(roleId, dto.DataPermissionIds, DataPermissionTypeEnum.RowPermission);

            return this.OkResponse(roleId);
        }

        [PermissionKey("DataPermission.ColumnPermission")]
        [HttpPost("ColumnDataPermission/{roleId}")]
        public async Task<ActionResult<ApiResponse<DataResponseDto>>> SetColumnDataPermission(long roleId, [FromBody] PermissionIdsDto dto)
        {
            await domainService.SetRoleDataPermission(roleId, dto.DataPermissionIds, DataPermissionTypeEnum.ColumnPermission);

            return this.OkResponse(roleId);
        }
    }
}
