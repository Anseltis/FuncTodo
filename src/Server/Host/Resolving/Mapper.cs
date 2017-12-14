using System.Drawing;
using AutoMapper;
using ESystems.FuncTodo.Server.Domain.Interface;
using ESystems.FuncTodo.Server.Host.Models;
using Microsoft.FSharp.Core;

namespace ESystems.FuncTodo.Server.Host.Resolving
{
    public static class Mapper
    {
        public static IMapperConfigurationExpression UseTodo(this IMapperConfigurationExpression config)
        {
            config.CreateMap<Model.Category, CategoryDataTransfer>();
            config.CreateMap<Model.Todo, TodoDataTransfer>();

            config.CreateMap<FSharpOption<Color>, Color?>()
                .ConvertUsing(color => color?.Value);

            return config;
        }
    }
}
