#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/ResellerLoungeMe.Web/ResellerLoungeMe.Web.csproj", "src/ResellerLoungeMe.Web/"]
COPY ["src/ResellerLoungeMe.Application/ResellerLoungeMe.Application.csproj", "src/ResellerLoungeMe.Application/"]
COPY ["src/ResellerLoungeMe.Core/ResellerLoungeMe.Core.csproj", "src/ResellerLoungeMe.Core/"]
COPY ["src/ResellerLoungeMe.Infrastructure/ResellerLoungeMe.Infrastructure.csproj", "src/ResellerLoungeMe.Infrastructure/"]
RUN dotnet restore "src/ResellerLoungeMe.Web/ResellerLoungeMe.Web.csproj"
COPY . .
WORKDIR "/src/src/ResellerLoungeMe.Web"
RUN dotnet build "ResellerLoungeMe.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResellerLoungeMe.Web.csproj" -c Release -o /app/publish
RUN apt-get update && apt-get install -y libgdiplus

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResellerLoungeMe.Web.dll"]