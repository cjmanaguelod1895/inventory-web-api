FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Inventory-Web-API.csproj", "InventoryWebAPIDeployment/"]
RUN dotnet restore "InventoryWebAPIDeployment/Inventory-Web-API.csproj"
WORKDIR "/src/InventoryWebAPIDeployment"
COPY . .
RUN dotnet build "Inventory-Web-API.csproj.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "Inventory-Web-API.csproj.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet InventoryWebAPIDeployment.dll