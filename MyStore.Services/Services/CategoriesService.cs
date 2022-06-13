using AutoMapper;
using Microsoft.Extensions.Logging;
using MyStore.DTOs;
using MyStore.Entities;
using MyStore.Interfaces;
using System;
using System.Collections.Generic;

namespace MyStore.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      

        public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public IEnumerable<CategoryModel> GetCategories()
        {                       
                var categories = _unitOfWork.Categories.GetAll();
                var results = _mapper.Map<IList<CategoryModel>>(categories);
                return results;     
        }

        public CategoryModel GetById(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            var result = _mapper.Map<CategoryModel>(category);
            return result;
        }

        public CategoryModel AddCategory(CategoryModel itemModel)
        {
            Category categoryToAdd = _mapper.Map<Category>(itemModel);            
            _unitOfWork.Categories.Insert(categoryToAdd);
            _unitOfWork.Save();

            return _mapper.Map<CategoryModel>(categoryToAdd);

        }

        public void Update(CategoryModel categoryModel)
        {
            var category = _unitOfWork.Categories.GetById(categoryModel.Id);
            _mapper.Map(categoryModel, category);
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }

        public Category Delete(int? id)
        {
            var _item = _unitOfWork.Categories.GetById(id);
            if (_item != null)
            {
                _unitOfWork.Categories.Delete(_item.Id);
                _unitOfWork.Save();
            }
            return _item;
        }
    }
}
