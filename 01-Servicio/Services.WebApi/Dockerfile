#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["01-Servicio/Services.WebApi/Services.WebApi.csproj", "01-Servicio/Services.WebApi/"]
COPY ["02-Aplicacion/Application.Main/Application.Main.csproj", "02-Aplicacion/Application.Main/"]
COPY ["02-Aplicacion/Application.DTO/Application.DTO.csproj", "02-Aplicacion/Application.DTO/"]
COPY ["05-Transversal/Transversal.Common/Transversal.Common.csproj", "05-Transversal/Transversal.Common/"]
COPY ["03-Dominio/Domain.Entity/Domain.Entity.csproj", "03-Dominio/Domain.Entity/"]
COPY ["03-Dominio/Domain.Interface/Domain.Interface.csproj", "03-Dominio/Domain.Interface/"]
COPY ["02-Aplicacion/Aplication.Validator/Application.Validator.csproj", "02-Aplicacion/Aplication.Validator/"]
COPY ["02-Aplicacion/Application.Interface/Application.Interface.csproj", "02-Aplicacion/Application.Interface/"]
COPY ["05-Transversal/Transversal.Logging/Transversal.Logging.csproj", "05-Transversal/Transversal.Logging/"]
COPY ["03-Dominio/Domain.Core/Domain.Core.csproj", "03-Dominio/Domain.Core/"]
COPY ["04-Infraestructura/Infraestructura.Interface/Infraestructura.Interface.csproj", "04-Infraestructura/Infraestructura.Interface/"]
COPY ["04-Infraestructura/Infraestructura.Repository/Infraestructura.Repository.csproj", "04-Infraestructura/Infraestructura.Repository/"]
COPY ["04-Infraestructura/Infraestructura.Data/Infraestructura.Data.csproj", "04-Infraestructura/Infraestructura.Data/"]
COPY ["05-Transversal/Transversal.Mapper/Transversal.Mapper.csproj", "05-Transversal/Transversal.Mapper/"]
RUN dotnet restore "01-Servicio/Services.WebApi/Services.WebApi.csproj"
COPY . .
WORKDIR "/src/01-Servicio/Services.WebApi"
RUN dotnet build "Services.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.WebApi.dll"]