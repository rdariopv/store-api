# Usa la imagen de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia el archivo .csproj y restaura las dependencias
COPY ["./store-api/store-api.csproj", "store-api/"]
COPY ["./xbiz-store/xbiz-store.csproj", "xbiz-store/"]
RUN dotnet restore "./store-api/store-api.csproj" 

# Copia el resto del código y compila la aplicación en modo Release
COPY . ./
# RUN dotnet publish -c Release -o out
RUN dotnet build "store-api.csproj" -c Release -o /app/build /p:Platform=x64 
FROM build AS publish
RUN dotnet publish "store-api.csproj" -c Release -o /app/publish /p:Platform=x64 

# Usa la imagen de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expone el puerto en el que escucha la API (normalmente el 80 o el 5000)
EXPOSE 80

# Comando para ejecutar la API
ENTRYPOINT ["dotnet", "store-api.dll"]
