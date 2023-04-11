FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Pacagroup.Ecommerce.Services.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /src/Pacagroup.Ecommerce.Services.WebApi/out ./
ENTRYPOINT ["dotnet", "Pacagroup.Ecommerce.Services.WebApi.dll"]
