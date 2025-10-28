
#------------------------------------------------------------------------------------
# Usa el SDK de .NET para construir ambos proyectos
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia los archivos de la solución y restaura las dependencias
COPY xbiz-store/*.csproj ./xbiz-store/
COPY store-api/*.csproj ./store-api/
COPY *.sln ./
RUN dotnet restore

# Copia el resto de los archivos del proyecto y compila en modo Release
COPY . .
RUN dotnet publish store-api/store-api.csproj -c Release -o out

# Usa el Runtime de .NET para la etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia el resultado de la compilación desde la etapa anterior
COPY --from=build-env /app/out .

# Configura Kestrel para que use la variable de entorno PORT inyectada por el host (Render)
ENV ASPNETCORE_URLS=http://+:$PORT

# Expone el puerto en el que la API escucha (ajústalo si usas otro puerto)
EXPOSE 8080

# Ejecuta la API
ENTRYPOINT ["dotnet", "store-api.dll"]

