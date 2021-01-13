#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIFramework.API/APIFramework.API.csproj", "APIFramework.API/"]
COPY ["APIFramework.Data/APIFramework.Data.csproj", "APIFramework.Data/"]
COPY ["APIFramework.Interfaces/APIFramework.Interfaces.csproj", "APIFramework.Interfaces/"]
COPY ["APIFramework.Models/APIFramework.Models.csproj", "APIFramework.Models/"]
COPY ["APIFramework.Business/APIFramework.Business.csproj", "APIFramework.Business/"]
COPY ["APIFramework.Mock.Business/APIFramework.Mock.Business.csproj", "APIFramework.Mock.Business/"]
COPY ["APIFramework.MockData/APIFramework.MockData.csproj", "APIFramework.MockData/"]
RUN dotnet restore "APIFramework.API/APIFramework.API.csproj"
COPY . .
WORKDIR "/src/APIFramework.API"
RUN dotnet build "APIFramework.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIFramework.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIFramework.API.dll"]