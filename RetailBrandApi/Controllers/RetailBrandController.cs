using RetailBrandApi.Models;
using RetailBrandApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace RetailBrandApi.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RetailBrandController : ControllerBase
    {
        private readonly StyleService _styleService;
        private readonly SkuService _skuService;

        public RetailBrandController(StyleService styleService, SkuService skuService)
        {
            _styleService = styleService;
            _skuService = skuService;
        }

        [HttpGet]
        public ActionResult<List<Style>> GetStyles() =>
            _styleService.Get();

        [HttpGet]
        public ActionResult<Style> GetStyle(int id)
        {
            var style = _styleService.Get(id);

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        [HttpGet]
        public ActionResult<Sku> GetSku(int id)
        {
            var sku = _skuService.GetSku(id);

            if (sku == null)
            {
                return NotFound();
            }

            return sku;
        }


        [HttpGet]
        public ActionResult<List<Sku>> GetSkuByStyle(int id)
        {
            var sku = _skuService.GetSkuByStyle(id);

            if (sku == null)
            {
                return NotFound();
            }

            return sku;
        }

        [HttpPost]
        public ActionResult<Style> PostStyle(Style style)
        {
            _styleService.Create(style);

            return CreatedAtRoute("GetStyle", new { id = style.StyleId }, style);
        }

        [HttpPost]
        public ActionResult<Sku> PostSku(Sku sku)
        {
            _skuService.Create(sku);

            return CreatedAtRoute("GetSku", new { id = sku.SkuNumber }, sku);
        }

        [HttpPut]
        public IActionResult PutStyle(Style styleIn)
        {
            var style = _styleService.Get(styleIn.StyleId);

            style.Brand = styleIn.Brand;
            style.Category = styleIn.Category;
            style.Description = styleIn.Description;
            style.Manufacturer = styleIn.Manufacturer;
            style.Type = styleIn.Type;

            if (style == null)
            {
                throw new NotImplementedException();
            }

            _styleService.Update(style);

            return NoContent();
        }

        [HttpPut]
        public IActionResult PutSku(Sku skuIn)
        {
            var sku = _skuService.GetSku(skuIn.SkuNumber);

            sku.StyleId = skuIn.StyleId;
            sku.InStock = skuIn.InStock;
            sku.Price = skuIn.Price;
            sku.Size = skuIn.Size;
            sku.Color = skuIn.Color;

            if (sku == null)
            {
                throw new NotImplementedException();
            }

            _skuService.Update(sku);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteStyle(int id)
        {
            var style = _styleService.Get(id);

            if (style == null)
            {
                throw new NotImplementedException();
            }

            _styleService.Remove(style.StyleId);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteSku(int id)
        {
            var sku = _skuService.GetSku(id);

            if (sku == null)
            {
                throw new NotImplementedException();
            }

            _skuService.Remove(sku.SkuNumber);

            return NoContent();
        }
    }
}
