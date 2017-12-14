namespace ESystems.FuncTodo.Server.DataService

open System

module public TodoService = 
    open ESystems.FuncTodo.Infrastructure.DataAccess
    open ESystems.FuncTodo.Server.DataAccess.Model.Value
    open ESystems.FuncTodo.Server.DataAccess.Model.Builder
    open ESystems.FuncTodo.Server.Domain.Interface.Model
    open ESystems.FuncTodo.Server.Domain.Interface.Tools

    let private toDesc (value: string) : Description =
        match value with
        | null -> None
        | desc -> Some desc

    let private toForeignKey (value: int Nullable) : ForeignKey =
        match value with
        | Value key -> Some key
        | Null -> None

    let private toDeadline (value: DateTime Nullable) : Deadline =
        match value with
        | Value deadline -> Some deadline
        | Null -> None

    let private toTodo (record: TodoValue Record) =
        let todo = record.Value
        { 
            Id = record.Key; 
            Title = todo.Title; 
            Desc = todo.Desc |> toDesc;
            Order = todo.Order;
            CategoryId = todo.CategoryId |> toForeignKey;
            Deadline = todo.Deadline |> toDeadline;
            Checked = todo.Checked
        }

    let getAll (repository : TodoValue IRepository) = 
        repository.GetAll() |> Seq.map toTodo

    let get (repository : TodoValue IRepository) id = 
        match repository.Get id with
        | null -> None
        | record -> record |> toTodo |> Some

    let add (repository : TodoValue IOrderedRepository) (title: string) =
        let last = repository.GetLast().Value
        let todo = TodoBuilder (Title = title, Order = last.Order + 1) |> TodoValue
        let id = repository.Add todo
        (id, todo) |> Record<TodoValue> |> toTodo

    let delete (repository : TodoValue IRepository) (id: int) = 
        let record = get repository id
        if record.IsSome then repository.Delete record.Value.Id
        record

    let private update (repository : TodoValue IRepository) (id: int) (builder: Todo -> TodoBuilder) =
        match get repository id with
        | Some record ->
            builder record 
            |> TodoValue
            |> fun value -> (record.Id, value)
            |> Record<TodoValue>
            |> repository.Update
            get repository id |> Some
        | None -> None
