
#------------------------------------------------------------------------------------
# Usa el SDK de .NET para construir ambos proyectos
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia los archivos de la solución y restaura las dependencias
COPY *.sln ./
COPY store-api/*.csproj ./store-api/
COPY xbiz-store/*.csproj ./xbiz-store/
RUN dotnet restore

# Copia el resto de los archivos del proyecto y compila en modo Release
COPY . .
RUN dotnet publish store-api/store-api.csproj -c Release -o out

# Usa el Runtime de .NET para la etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia el resultado de la compilación desde la etapa anterior
COPY --from=build-env /app/out .

# Expone el puerto en el que la API escucha (ajústalo si usas otro puerto)
EXPOSE 80

# Ejecuta la API
ENTRYPOINT ["dotnet", "store-api.dll"]

