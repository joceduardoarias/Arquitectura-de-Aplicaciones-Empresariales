FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Pacagroup.Ecommerce.Services.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/Pacagroup.Ecommerce.Services.WebApi/out ./
ENTRYPOINT ["dotnet", "Pacagroup.Ecommerce.Services.WebApi.dll"]
