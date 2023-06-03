FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# Copy csproj and restore
COPY ChatGPTGeneratedSimpleWebApplication/*.csproj ChatGPTGeneratedSimpleWebApplication/
RUN dotnet restore "ChatGPTGeneratedSimpleWebApplication/ChatGPTGeneratedSimpleWebApplication.csproj"

# Copy everything else and build
COPY . .
WORKDIR ChatGPTGeneratedSimpleWebApplication
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release -o /app --no-restore

# Final stage / image, using the official Microsoft .NET Core runtime base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app .

# Set the ASP.NET Core URLs and the Docker container port
ENV ASPNETCORE_URLS="http://+:80;https://+:443"
EXPOSE 80
EXPOSE 443

# Start the application
ENTRYPOINT ["dotnet", "ChatGPTGeneratedSimpleWebApplication.dll"]