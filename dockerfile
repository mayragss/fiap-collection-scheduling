# Define a imagem base que será utilizada para a construção da imagem do Docker
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Define a imagem que será utilizada para a construção do projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CollectionSchedulingAPI/CollectionSchedulingAPI.csproj", "CollectionSchedulingAPI/"]
RUN dotnet restore "CollectionSchedulingAPI/CollectionSchedulingAPI.csproj"
COPY . .
WORKDIR "/src/CollectionSchedulingAPI"
RUN dotnet build "CollectionSchedulingAPI.csproj" -c Release -o /app/build

# Define a imagem que será utilizada para rodar o projeto em produção
FROM build AS publish
RUN dotnet publish "CollectionSchedulingAPI.csproj" -c Release -o /app/publish

# Define a imagem final que será executada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionSchedulingAPI.dll"]