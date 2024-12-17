# Use the official ASP.NET Core build image for .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the project files
COPY *.sln ./
COPY BookStoreApp/*.csproj ./BookStoreApp/

# Restore the project dependencies
RUN dotnet restore

# Copy the rest of the application files and build the app
COPY . ./
WORKDIR /app/BookStoreApp
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image for .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/BookStoreApp/out .

# Expose the port the app runs on
EXPOSE 80

# Set the environment variable for ASP.NET Core to listen on port 80
ENV ASPNETCORE_URLS=http://+:80

# Run the application
ENTRYPOINT ["dotnet", "BookStoreApp.dll"]
