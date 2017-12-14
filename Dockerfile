FROM microsoft/aspnetcore-build AS build-env
WORKDIR /app

COPY *.sln ./
COPY . ./

WORKDIR /app/src/Server/Host
RUN dotnet restore

RUN dotnet publish -c Release -o out


# build runtime image
FROM microsoft/dotnet
WORKDIR /app
COPY --from=build-env /app/src/Server/Host/out .

ENTRYPOINT ["dotnet", "ESystems.FuncTodo.Server.Host.dll"]
EXPOSE 5000

