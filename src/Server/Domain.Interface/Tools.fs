namespace ESystems.FuncTodo.Server.Domain.Interface

module public Tools = 
    open System

    let public (|Null|Value|) (nullable: _ Nullable) =
        match nullable with
        | some when some.HasValue -> Value some.Value
        | _ -> Null

    let public toColor (value: int Nullable) = 
        match value with 
        | Value color -> color |> Drawing.Color.FromArgb |> Some
        | Null -> None

    let public fromColor (value: Drawing.Color option) : int Nullable = 
        match value with 
        | Some color -> color.ToArgb() |> Nullable<int>
        | None -> Nullable<int>()


