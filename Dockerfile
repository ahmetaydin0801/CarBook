# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the entire solution
COPY . .

# Restore dependencies for the entire solution
RUN dotnet restore CarBook.sln

# Navigate to the WebAPI project folder
WORKDIR /src/Presentation/CarBook.WebApi

# Publish the WebAPI project
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expose the port
EXPOSE 5000

# Start the application
ENTRYPOINT ["dotnet", "CarBook.WebApi.dll"]
