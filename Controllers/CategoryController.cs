using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.DTOs;
using MyStore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStore.Interfaces;
using MyStore.Services.Services;
using Microsoft.Extensions.Logging;

namespace MyStore.Controllers
{
    //[Authorize()]
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IBaseCrudDataService<CategoryModel, Category> _basedataService;

        public CategoryController(ILogger<CategoryController> logger,
                                  IBaseCrudDataService<CategoryModel, Category> basedataService)
        {
            _logger = logger;
            _basedataService = basedataService;
        }

        [HttpGet]
        public ActionResult<CategoryModel> GetCategories()
        {
            var result = _basedataService.Get();
            return Ok(result);

            #region
            //var categoriesDtos = new List<CategoryModel>();
            //categories.ForEach(category =>
            //{
            //    var categoryModel = new CategoryModel
            //    {
            //        Id = category.Id,
            //        CategoryName = category.CategoryName

            //    };
            //    foreach (var product in category.Products)
            //    {
            //        var productModel = new ProductModel
            //        {
            //            Id = product.Id,
            //            ProductName = product.ProductName,
            //            Unitprice = product.Unitprice

            //        };
            //        categoryModel.Products.Add(productModel);
            //    }
            //    categories.Add(category);
            //});
            #endregion
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _basedataService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CategoryModel itemModel)
        {
            if (itemModel == null)
            {
                return BadRequest();
            }
            var category = _basedataService.Insert(itemModel);
            return Ok(category);

            #region
            //if (itemModel == null)
            //{
            //    return BadRequest();
            //}
            //var categoryMapped = _mapper.Map<Category>(itemModel);
            //_unitOfWork.Categories.Insert(categoryMapped);
            //_unitOfWork.Save(); // Categories.Save();
            //return Ok(categoryMapped);
            #endregion
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryModel categoryModel)
        {

            if (categoryModel == null || categoryModel.Id != id)
            {
                return BadRequest();
            }
            _basedataService.Update(categoryModel, id);

            if (categoryModel == null)
            {
                return NotFound();
            }
            return Ok(categoryModel);

            #region
            //var _item = _unitOfWork.Categories.GetById(id);
            //_mapper.Map(itemModel, _item);            
            //_unitOfWork.Categories.Update(_item);
            //_unitOfWork.Save();
            #endregion
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            _basedataService.Delete(id);
            return Ok();

            #region
            //var _item = _unitOfWork.Categories.GetById(id);
            //_unitOfWork.Categories.Delete(_item.Id);
            //_unitOfWork.Save();
            //var _items = _unitOfWork.GenericRepository.GetAll();
            #endregion

        }
    }
}

