using DataPermission.Api.Attributes;
using DataPermission.Api.Contracts.Dtos.Request;
using DataPermission.Api.Contracts.Dtos.Response;
using DataPermission.Api.Contracts.Mapping;
using DataPermission.Domain.Entities;
using DataPermission.Domain.Interfaces;
using DataPermission.Domain.Services;
using DataPermission.Infra.Extensions;
using DataPermission.Infra.Options;
using DataPermission.Infra.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataPermission.Api.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RowDataPermissionController(IRowDataPermissionRepository repository, IValidator<RowPermissionDto> validator, RowPermissionMapper mapper, RowPermissionService domainService,CommonQuery commonQuery) : ControllerBase
    {

        [HttpGet("Detail/{id}")]
        [PermissionKey("RowPermission.Detail")]
        public async Task<ActionResult<ApiResponse<RowPermissionList>>> Detail(long id)
        {

            var query = commonQuery.Query<RowPermissionList>();
            var menu = await query.FirstOrDefaultAsync(t => t.Id == id);
            return this.OkResponse(menu);
        }
        [HttpGet("Pagination")]
        [PermissionKey("RowPermission.List")]
        public async Task<ActionResult<ApiResponse<PaginationResponse<RowPermissionList>>>> ListByPagination(int pageIndex = 1, int pageSize = 10, string tableName = "", string description = "")
        {

            var query = commonQuery.Query<RowPermissionList>();

            if (!string.IsNullOrWhiteSpace(tableName))
            {
                query = query.Where(t => EF.Functions.Like(t.FullTableName, tableName));
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(t => EF.Functions.Like(t.Description, description));
            }

            var res = await query.ToPaginationResponseAsync(pageIndex, pageSize);

            return this.OkResponse(res);
        }

        [HttpPost]
        [PermissionKey("RowPermission.Create")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Create(RowPermissionDto dto)
        {
            await ValidationHelper.ValidateModelAsync(dto, validator);

            bool exists = await domainService.ExistsConflictAsync(dto.FullTableName, dto.DataScopeType, dto.ScopeValue, dto.ScopeField);

            if (exists) return this.FailResponse("row rule exists");

            var entity = mapper.ToEntity(dto);

            await repository.AddAsync(entity);

            return this.OkResponse(entity.Id);
        }

        [HttpPut("{id}")]
        [PermissionKey("RowPermission.Update")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Update(long id, [FromBody] RowPermissionDto dto)
        {
            await ValidationHelper.ValidateModelAsync(dto, validator);

            var info = await commonQuery.Query<RowPermissionList>().FirstOrDefaultAsync(t => t.Id == id);
            if (info == null) return this.FailResponse("not found");


            bool exists = await domainService.ExistsConflictAsync(dto.FullTableName, dto.DataScopeType, dto.ScopeValue, dto.ScopeField, id);

            if (exists) return this.FailResponse("row rule exists");
            mapper.UpdateDtoToEntity(dto, info);

            return this.OkResponse(id);
        }

        [HttpDelete("{id}")]
        [PermissionKey("RowPermission.Delete")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Delete(long id)
        {

            var info = await commonQuery.Query<RowPermissionList>().FirstOrDefaultAsync(t => t.Id == id);
            if (info == null) return this.FailResponse(" not found");
            repository.Delete(info);

            return this.OkResponse(id);
        }
    
    }
}
