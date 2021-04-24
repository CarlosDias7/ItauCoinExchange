#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Itau.CoinExchange.Api/Itau.CoinExchange.Api.csproj", "src/Itau.CoinExchange.Api/"]
COPY ["src/Itau.CoinExchange.Application/Itau.CoinExchange.Application.csproj", "src/Itau.CoinExchange.Application/"]
COPY ["src/Itau.CoinExchange.Domain/Itau.CoinExchange.Domain.csproj", "src/Itau.CoinExchange.Domain/"]
COPY ["src/Itau.CoinExchange.Domain.Base/Itau.CoinExchange.Domain.Base.csproj", "src/Itau.CoinExchange.Domain.Base/"]
COPY ["src/Itau.CoinExchange.Repositories.Base/Itau.CoinExchange.Repositories.Base.csproj", "src/Itau.CoinExchange.Repositories.Base/"]
COPY ["src/Itau.CoinExchange.Application.Contracts/Itau.CoinExchange.Application.Contracts.csproj", "src/Itau.CoinExchange.Application.Contracts/"]
COPY ["src/Itau.CoinExchange.DependenciesInjections/Itau.CoinExchange.DependenciesInjections.csproj", "src/Itau.CoinExchange.DependenciesInjections/"]
COPY ["src/Itau.CoinExchange.Data/Itau.CoinExchange.Data.csproj", "src/Itau.CoinExchange.Data/"]
COPY ["src/Itau.CoinExchange.Repositories/Itau.CoinExchange.Repositories.csproj", "src/Itau.CoinExchange.Repositories/"]
RUN dotnet restore "src/Itau.CoinExchange.Api/Itau.CoinExchange.Api.csproj"
COPY . .
WORKDIR "/src/src/Itau.CoinExchange.Api"
RUN dotnet build "Itau.CoinExchange.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Itau.CoinExchange.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Itau.CoinExchange.Api.dll"]