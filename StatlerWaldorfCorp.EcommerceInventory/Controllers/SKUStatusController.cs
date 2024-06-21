using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorfCorp.EcommerceInventory.Model;
using StatlerWaldorfCorp.EcommerceInventory.Repository;

namespace StatlerWaldorfCorp.EcommerceInventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SKUStatusController : ControllerBase
    {
        private ISKUStatusRepository skuStatusRepository;
        private ILogger<SKUStatusController> logger;

        public SKUStatusController(ISKUStatusRepository skuStatusRepository, ILogger<SKUStatusController> logger)
        {
            this.skuStatusRepository = skuStatusRepository;
            this.logger = logger;
        }

        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            logger.LogInformation("Handling request for SKU " + sku.ToString());
            return this.Ok(this.skuStatusRepository.Get(sku));
        }

        [HttpPut("{sku}")]
        public IActionResult Put([FromBody]SKUStatus skuStatus)
        {
            return this.Ok(this.skuStatusRepository.Add(skuStatus));
        }
    }
}

// sku = stock keeping unit