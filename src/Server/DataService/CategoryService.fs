namespace ESystems.FuncTodo.Server.DataService

module public CategoryService = 
    open System
    open ESystems.FuncTodo.Infrastructure.DataAccess
    open ESystems.FuncTodo.Server.DataAccess.Model.Value
    open ESystems.FuncTodo.Server.DataAccess.Model.Builder
    open ESystems.FuncTodo.Server.Domain.Interface.Tools
    open ESystems.FuncTodo.Server.Domain.Interface.Model

    let private toCategory (record: CategoryValue Record) =
        let category = record.Value
        { 
            Id = record.Key; 
            Name = category.Name; 
            Color = category.Color |> toColor; 
            Order = category.Order
        }

    let getAll (repository : CategoryValue IRepository) = 
        repository.GetAll() |> Seq.map toCategory 

    let get (repository : CategoryValue IRepository) id = 
        match repository.Get id with
        | null -> None
        | record -> record |> toCategory |> Some

    let add (repository : CategoryValue IOrderedRepository) (name: string) =
        let last = repository.GetLast().Value
        let category = CategoryBuilder (Name = name, Order = last.Order + 1) |> CategoryValue
        let id = repository.Add category
        (id, category) |> Record<CategoryValue> |> toCategory

    let delete (repository : CategoryValue IRepository) (id: int) = 
        let record = get repository id
        if record.IsSome then repository.Delete record.Value.Id
        record

    let private update (repository : CategoryValue IRepository) (id: int) (builder: Category -> CategoryBuilder) =
        match get repository id with
        | Some record ->
            builder record 
            |> CategoryValue
            |> fun value -> (record.Id, value)
            |> Record<CategoryValue>
            |> repository.Update
            get repository id |> Some
        | None -> None
        
    let changeName (repository : CategoryValue IRepository) (id: int) (name: string) =
        update repository id
        <| fun record -> CategoryBuilder (Name = name, Order = record.Order, Color = (record.Color |> fromColor))

    let changeColor (repository : CategoryValue IRepository) (id: int) (color: Drawing.Color option) =
        update repository id
        <| fun record -> CategoryBuilder (Name = record.Name, Order = record.Order, Color = (color |> fromColor))

    let changeOrder (repository : CategoryValue IRepository) (id: int) (order: int) =
        update repository id
        <| fun record -> CategoryBuilder (Name = record.Name, Order = order, Color = (record.Color |> fromColor))

