namespace ESystems.FuncTodo.Server.Domain.Interface

open System

module Model =
    type Key = int
    type ForeignKey = int option
    type Name = string
    type Title = string
    type Description = string option
    type Color = Drawing.Color option
    type Deadline = DateTime option
    type Checked = bool
    type Order = int

    type Category = {
        Id: Key;
        Name: Name;
        Color: Color;
        Order: Order
    }

    type Todo = {
        Id: Key;
        Title: Title;
        Desc: Description;
        Deadline: Deadline;
        Checked: Checked;
        CategoryId: ForeignKey;
        Order: Order
    }
