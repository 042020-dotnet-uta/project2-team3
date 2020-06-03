using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using System.Linq;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class ResourceUsageController : ControllerBase
    {
        private readonly ILogger<ResourceUsageController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IBill _billRepository;

        public ResourceUsageController(ILogger<ResourceUsageController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IBill billRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._billRepository = billRepository;
        }

        [HttpGet]
        [Route("ResourceProjections")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetResourceProjectionsInPeriod()
        {
            var currentBillingPeriod = await _billRepository.GetCurrentBillingPeriod();
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var projections = await _billRepository.GetProjectedResourceUsages((int)tenantId, currentBillingPeriod);
                var projectionDTOs = projections.Select(p => new DTO.ProjectedResourceUsageDTO(p)).ToList();

                return new ObjectResult(projectionDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view resource projections.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("ResourceProjection")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetResourceProjectionForResource(ResourceType resource)
        {
            var currentBillingPeriod = await _billRepository.GetCurrentBillingPeriod();
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var projection = await _billRepository.GetProjectedResourceUsage((int)tenantId, resource, currentBillingPeriod);
                if (projection == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("No resource usage found for the selected resource.")
                                    .Code(404)
                                    .Build();
                    return err;

                }
                var projectionDTO = new DTO.ProjectedResourceUsageDTO(projection);

                return new ObjectResult(projectionDTO);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view resource projections.")
                                .Code(403)
                                .Build();
                return err;
            }
        }
    }
}
