using System;
using System.Drawing;
using AutoMapper;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using ESystems.FuncTodo.Server.DataService;
using ESystems.FuncTodo.Server.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESystems.FuncTodo.Server.Host.Controllers
{
    [Route("api/category")]
    public class CategoryController: Controller
    {
        private readonly IOrderedRepository<CategoryValue> _repository;
        private readonly IMapper _mapper;

        public CategoryController(IOrderedRepository<CategoryValue> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("{id}"), HttpGet]
        public CategoryDataTransfer Get(int id)
        {
            var category = CategoryService.get(_repository, id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryDataTransfer>(category.Value);
        }

        [HttpGet]
        public CategoryDataTransfer[] Get()
        {
            var categories = CategoryService.getAll(_repository);
            return _mapper.Map<CategoryDataTransfer[]>(categories);
        }

        [Route("add"), HttpPost]
        public int Add(string name)
        {
            var category = CategoryService.add(_repository, name);
            return category.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(int id)
        {
            CategoryService.delete(_repository, id);
        }

        [Route("{id}/name"), HttpPut]
        public void ChangeName(int id, string name)
        {
            CategoryService.changeName(_repository, id, name);
        }

        [Route("{id}/order"), HttpPut]
        public void ChangeOrder(int id, int order)
        {
            CategoryService.changeOrder(_repository, id, order);
        }

        [Route("{id}/color"), HttpPut]
        public void ChangeColor(int id, Color color)
        {
            CategoryService.changeColor(_repository, id, color);
        }

    }
}
