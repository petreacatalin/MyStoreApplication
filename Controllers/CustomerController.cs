using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.DTOs;
using MyStore.Entities;
using MyStore.Interfaces;
using MyStore.Services.Services;
using System;
using System.Collections.Generic;

namespace MyStore.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {        
        private readonly ICustomersService _customerService;
        private readonly IBaseCrudDataService<CustomerModel, Customer> _basedataService;

        public CustomerController(ICustomersService customerService, 
                                  IBaseCrudDataService<CustomerModel, Customer> basedataService)
        {
            _customerService = customerService;
            _basedataService = basedataService;

        }

        [HttpGet]
        public ActionResult<CustomerModel> GetCustomers()
        {
            //var categories = _unitOfWork.Customers.GetAll();
            //var categoriesDto = _mapper.Map<IEnumerable<Customer>>(categories);
            //return categoriesDto;    
                        
                var result = _basedataService.Get();
                return Ok(result);           
                  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var item = _unitOfWork.Customers.GetById(id);
            //var itemDto = _mapper.Map<CustomerModel>(item);

            var result= _basedataService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        
        [HttpPost(Name = "PostCustomer")]
        public IActionResult Post([FromBody] CustomerModel itemModel)
        {
            #region
            //try
            //{
            //    var customer = _mapper.Map<Customer>(itemModel);
            //    _unitOfWork.Customers.Insert(customer);
            //    _unitOfWork.Save();
            //    return CreatedAtRoute("PostCustomer", new { id = customer.Id });
            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}
            #endregion
            
            if (itemModel == null)
            {
                return BadRequest();
            }
            var customer = _basedataService.Insert(itemModel);
            return Ok(customer);

        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerModel customerModel)
        {
            #region 
            //if (!ModelState.IsValid || id < 1)
            //{
            //    return BadRequest(ModelState);
            //}

            //var _item = _unitOfWork.Customers.GetById(id);

            //if (_item == null)
            //{
            //    return NotFound();
            //}

            //_mapper.Map(customerModel, _item);

            //_unitOfWork.Customers.Update(_item);
            //_unitOfWork.Save();
            //return Ok(_item);
            #endregion

            if (customerModel == null || customerModel.Id != id)
            {
                return BadRequest();
            }
            _basedataService.Update(customerModel, id);

            if (customerModel == null)
            {
                return NotFound();
            }
            return Ok(customerModel);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            #region back-up code
            //var _item = _unitOfWork.Customers.GetById(id);

            //if (_item == null)
            //{
            //    return NotFound();
            //}

            //_unitOfWork.Customers.Delete(_item.Id);
            //_unitOfWork.Save();
            //return Ok();
            #endregion

            if (id == null)
            {
                return NotFound();
            }
            _basedataService.Delete(id);            
            return Ok();
        }
    }
}

