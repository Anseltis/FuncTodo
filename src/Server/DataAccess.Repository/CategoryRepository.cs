using System;
using System.Collections.Generic;
using System.Linq;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Entity;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using Microsoft.EntityFrameworkCore;

namespace ESystems.FuncTodo.Server.DataAccess.Repository
{
    public class CategoryRepository : IOrderedRepository<CategoryValue>
    {
        private readonly IContextFactory<ITodoContext> _contextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="contextFactory">Database context factory. </param>
        public CategoryRepository(IContextFactory<ITodoContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        /// <summary>
        /// Gets full item list.
        /// </summary>
        /// <returns>Full item list. </returns>
        public IEnumerable<Record<CategoryValue>> GetAll()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Categories
                    .AsEnumerable()
                    .Select(category => category.Record)
                    .ToList();
            }
        }

        /// <summary>
        /// Gets item list bu id.
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Item with current primary key </returns>
        public Record<CategoryValue> Get(int id)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Categories.Where(c => c.Id == id)
                    .ToList()
                    .Select(category => category.Record)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Saves todo into the repository.
        /// </summary>
        /// <param name="value">Saving item. </param>
        /// <returns>Saved item. </returns>
        public int Add(CategoryValue value)
        {
            var entity = new Category(value);
            using (var context = _contextFactory.CreateContext())
            {
                context.Categories.Add(entity);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    //throw new DataValidationException();
                }

                return entity.Id;
            }
        }


        /// <summary>
        /// Saves category into the repository.
        /// </summary>
        /// <param name="record">Saving item. </param>
        /// <returns>Saved item. </returns>
        public void Update(Record<CategoryValue> record)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var entry = context.Entry(record);
                entry.State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    //throw new DataValidationException();
                }
            }
        }

        /// <summary>
        /// Deletes item from the repository.
        /// </summary>
        /// <param name="id">Deleting item. </param>
        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateContext())
            {
                foreach (var entity in context.Categories.Where(record => record.Id == id))
                {
                    if (entity.Todoes.Any())
                    {
                        //throw new ForeignKeyConstraintException($"{nameof(Todo)} - {nameof(Category)}");
                    }

                    context.Categories.Remove(entity);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a last record by order
        /// </summary>
        /// <returns>Last record</returns>
        public Record<CategoryValue> GetLast()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Categories
                    .OrderByDescending(category => category.Id)
                    .Take(1)
                    .ToList()
                    .Select(category => category.Record)
                    .FirstOrDefault();
            }
        }
    }
}