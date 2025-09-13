# Usa una imagen base de .NET 8 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY ./LibraryApp/*.csproj ./LibraryApp/
RUN dotnet restore ./LibraryApp/

# Copia el resto de los archivos y compila la aplicación
COPY . .

# Compila el proyecto específico dentro de la subcarpeta
RUN dotnet publish ./LibraryApp/LibraryApp.csproj -c Release -o /out

# Establece la imagen base para el entorno de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia la aplicación publicada
COPY --from=build /out .

# Expone el puerto en el que se ejecutará la aplicación
EXPOSE 8080

# Comando de inicio
# El nombre del .dll debe ser correcto, basado en el nombre de tu proyecto
ENTRYPOINT ["dotnet", "LibraryApp.dll"]