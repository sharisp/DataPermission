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
    public class ColumnDataPermissionController(IColumnDataPermissionRepository repository, IValidator<ColumnPermissionDto> validator, ColumnPermissionMapper mapper, ColumnPermissionService domainService,CommonQuery commonQuery) : ControllerBase
    {

        [HttpGet("Detail/{id}")]
        [PermissionKey("ColumnPermission.Detail")]
        public async Task<ActionResult<ApiResponse<ColumnPermissionBlackList>>> Detail(long id)
        {           
            var query = commonQuery.Query<ColumnPermissionBlackList>();
            var menu = await query.FirstOrDefaultAsync(t => t.Id == id);
            return this.OkResponse(menu);
        }
        [HttpGet("Pagination")]
        [PermissionKey("ColumnPermission.List")]
        public async Task<ActionResult<ApiResponse<PaginationResponse<ColumnPermissionBlackList>>>> ListByPagination(int pageIndex = 1, int pageSize = 10, string tableName = "", string description = "")
        {


            var query = commonQuery.Query<ColumnPermissionBlackList>();

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
        [PermissionKey("ColumnPermission.Create")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Create(ColumnPermissionDto dto)
        {
            await ValidationHelper.ValidateModelAsync(dto, validator);


            var exists = await domainService.ExistsConflictAsync(dto.FullTableName, dto.ColumnName);
            if (exists) return this.FailResponse("column rule exists");

            var entity = mapper.ToEntity(dto);

            await repository.AddAsync(entity);

            return this.OkResponse(entity.Id);
        }

        [HttpPut("{id}")]
        [PermissionKey("ColumnPermission.Update")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Update(long id, [FromBody] ColumnPermissionDto dto)
        {
            await ValidationHelper.ValidateModelAsync(dto, validator);

            var info = await commonQuery.Query<ColumnPermissionBlackList>().FirstOrDefaultAsync(t => t.Id == id);
            if (info == null) return this.FailResponse("not found");


            var exists = await domainService.ExistsConflictAsync(dto.FullTableName, dto.ColumnName, id);
            if (exists) return this.FailResponse("column rule exists");
            mapper.UpdateDtoToEntity(dto, info);

            return this.OkResponse(id);
        }

        [HttpDelete("{id}")]
        [PermissionKey("ColumnPermission.Delete")]
        public async Task<ActionResult<ApiResponse<BaseResponse>>> Delete(long id)
        {

            var info = await commonQuery.Query<ColumnPermissionBlackList>().FirstOrDefaultAsync(t => t.Id == id);
            if (info == null) return this.FailResponse(" not found");
            repository.Delete(info);

            return this.OkResponse(id);
        }

      
    }
}
