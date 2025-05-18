# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pacagroup.Ecommerce.Services.WebApi/Pacagroup.Ecommerce.Services.WebApi.csproj", "Pacagroup.Ecommerce.Services.WebApi/"]
COPY ["Pacagroup.Ecommerce.Application.DTO/Pacagroup.Ecommerce.Application.DTO.csproj", "Pacagroup.Ecommerce.Application.DTO/"]
COPY ["Pacagroup.Ecommerce.Application.Interface/Pacagroup.Ecommerce.Application.Interface.csproj", "Pacagroup.Ecommerce.Application.Interface/"]
COPY ["Pacagroup.Ecommerce.Domain.Entity/Pacagroup.Ecommerce.Domain.csproj", "Pacagroup.Ecommerce.Domain.Entity/"]
COPY ["Pacagroup.Ecommerce.Transversal.Common/Pacagroup.Ecommerce.Transversal.Common.csproj", "Pacagroup.Ecommerce.Transversal.Common/"]
COPY ["Pacagroup.Ecommerce.Application.Main/Pacagroup.Ecommerce.Application.UseCase.csproj", "Pacagroup.Ecommerce.Application.Main/"]
COPY ["Pacagroup.Ecommerce.Application.Validator/Pacagroup.Ecommerce.Application.Validator.csproj", "Pacagroup.Ecommerce.Application.Validator/"]
COPY ["Pacagroup.Ecommerce.Infrastructure/Pacagroup.Ecommerce.Infrastructure.csproj", "Pacagroup.Ecommerce.Infrastructure/"]
COPY ["Pacagroup.Ecommerce.Persistence/Pacagroup.Ecommerce.Persistence.csproj", "Pacagroup.Ecommerce.Persistence/"]
RUN dotnet restore "./Pacagroup.Ecommerce.Services.WebApi/Pacagroup.Ecommerce.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Pacagroup.Ecommerce.Services.WebApi"
RUN dotnet build "./Pacagroup.Ecommerce.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pacagroup.Ecommerce.Services.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Instala OpenTelemetry AutoInstrumentation en tiempo de ejecución
USER root

ARG OTEL_VERSION=1.0.0
ADD https://github.com/open-telemetry/opentelemetry-dotnet-instrumentation/releases/download/v${OTEL_VERSION}/otel-dotnet-auto-install.sh /otel-dotnet-auto-install.sh

RUN apt-get update && apt-get install -y curl unzip && \
    OTEL_DOTNET_AUTO_HOME="/otel-dotnet-auto" sh /otel-dotnet-auto-install.sh && \
    rm /otel-dotnet-auto-install.sh

USER app


# ✅ Ejecutar el script antes de iniciar la app
ENTRYPOINT ["dotnet", "Pacagroup.Ecommerce.Services.WebApi.dll"]

