# Usa una imagen base de .NET 8 SDK para compilar la aplicaci�n
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY ./LibraryApp/*.csproj ./LibraryApp/
RUN dotnet restore ./LibraryApp/

# Copia el resto de los archivos y compila la aplicaci�n
COPY . .

# Compila el proyecto espec�fico dentro de la subcarpeta
RUN dotnet publish ./LibraryApp/LibraryApp.csproj -c Release -o /out

# Establece la imagen base para el entorno de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia la aplicaci�n publicada
COPY --from=build /out .

# Expone el puerto en el que se ejecutar� la aplicaci�n
EXPOSE 8080

# Comando de inicio
# El nombre del .dll debe ser correcto, basado en el nombre de tu proyecto
ENTRYPOINT ["dotnet", "LibraryApp.dll"]