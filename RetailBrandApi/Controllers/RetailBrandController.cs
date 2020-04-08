using RetailBrandApi.Models;
using RetailBrandApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace RetailBrandApi.Controllers
{
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
        [Route("demo/api/styles/")]
        public ActionResult<List<Style>> GetStyles() =>
            _styleService.Get();

        [HttpGet]
        [Route("demo/api/styles/{styleId}")]
        public ActionResult<Style> GetStyle(int styleId)
        {
            var style = _styleService.Get(styleId);

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        [HttpGet]
        [Route("demo/api/skus/{styleId}")]
        public ActionResult<Sku> GetSku(int styleId)
        {
            var sku = _skuService.Get(styleId);

            if (sku == null)
            {
                return NotFound();
            }

            return sku;
        }


        [HttpGet]
        [Route("demo/api/styles/{styleId}/skus")]
        public ActionResult<List<Sku>> GetSkuByStyle(int styleId)
        {
            var sku = _skuService.GetSkuByStyle(styleId);

            if (sku == null)
            {
                return NotFound();
            }

            return sku;
        }

        [HttpPost]
        [Route("demo/api/styles")]
        public ActionResult<Style> PostStyle(Style style)
        {
            _styleService.Create(style);

            return CreatedAtRoute("GetStyle", new { id = style.StyleId }, style);
        }

        [HttpPost]
        [Route("demo/api/skus")]
        public ActionResult<Sku> PostSku(Sku sku)
        {
            _skuService.Create(sku);

            return CreatedAtRoute("GetSku", new { id = sku.SkuNumber }, sku);
        }

        [HttpPut]
        [Route("demo/api/styles/{styleId}")]
        public IActionResult PutStyle(Style style)
        {
            var styleLocal = _styleService.Get(style.StyleId);

            styleLocal.Brand = style.Brand;
            styleLocal.Category = style.Category;
            styleLocal.Description = style.Description;
            styleLocal.Manufacturer = style.Manufacturer;
            styleLocal.Type = style.Type;

            if (styleLocal == null)
            {
                throw new NotImplementedException();
            }

            _styleService.Update(styleLocal);

            return NoContent();
        }

        [HttpPut]
        [Route("demo/api/skus/{styleId}")]
        public IActionResult PutSku(Sku sku)
        {
            var skuLocal = _skuService.Get(sku.SkuNumber);

            skuLocal.StyleId = sku.StyleId;
            skuLocal.InStock = sku.InStock;
            skuLocal.Price = sku.Price;
            skuLocal.Size = sku.Size;
            skuLocal.Color = sku.Color;

            if (skuLocal == null)
            {
                throw new NotImplementedException();
            }

            _skuService.Update(sku);

            return NoContent();
        }

        [HttpDelete]
        [Route("demo/api/styles/{styleId}")]
        public IActionResult DeleteStyle(int styleId)
        {
            var style = _styleService.Get(styleId);

            if (style == null)
            {
                throw new NotImplementedException();
            }

            _styleService.Remove(style.StyleId);

            return NoContent();
        }

        [HttpDelete]
        [Route("demo/api/skus/{SkuNumber}")]
        public IActionResult DeleteSku(int SkuNumber)
        {
            var sku = _skuService.Get(SkuNumber);

            if (sku == null)
            {
                throw new NotImplementedException();
            }

            _skuService.Remove(sku.SkuNumber);

            return NoContent();
        }
    }
}
