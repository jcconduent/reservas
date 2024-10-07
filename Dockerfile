# Establece la imagen base para .NET SDK 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos de la aplicación y compila
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Establece la imagen base para el runtime de .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto en el que tu aplicación correrá
EXPOSE 80
ENTRYPOINT ["dotnet", "reservasjc.dll"]
