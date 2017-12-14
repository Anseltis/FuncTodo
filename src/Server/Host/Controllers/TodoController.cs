using System;
using AutoMapper;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using ESystems.FuncTodo.Server.DataService;
using ESystems.FuncTodo.Server.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESystems.FuncTodo.Server.Host.Controllers
{
    [Route("api/todo")]
    public class TodoController: Controller
    {
        private readonly IOrderedRepository<TodoValue> _repository;
        private readonly IMapper _mapper;

        public TodoController(IOrderedRepository<TodoValue> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("{id}"), HttpGet]
        public TodoDataTransfer Get(int id)
        {
            var todo = TodoService.get(_repository, id);

            if (todo == null)
            {
                return null;
            }

            return _mapper.Map<TodoDataTransfer>(todo.Value);
        }

        [HttpGet]
        public TodoDataTransfer[] Get()
        {
            var categories = TodoService.getAll(_repository);
            return _mapper.Map<TodoDataTransfer[]>(categories);
        }

        [Route("add"), HttpPost]
        public int Add(string name)
        {
            var category = TodoService.add(_repository, name);
            return category.Id;
        }

        [Route("{id}"), HttpDelete]
        public void Delete(int id)
        {
            TodoService.delete(_repository, id);
        }
    }
}
