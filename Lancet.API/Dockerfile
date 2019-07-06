FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["Lancet.API/Lancet.API.csproj", "Lancet.API/"]
COPY ["Lancet.Repository/Lancet.Repository.csproj", "Lancet.Repository/"]
COPY ["Lancet.Models/Lancet.Models.csproj", "Lancet.Models/"]
COPY ["Lancet.Service/Lancet.Service.csproj", "Lancet.Service/"]
RUN dotnet restore "Lancet.API/Lancet.API.csproj"
COPY . .
WORKDIR "/src/Lancet.API"
RUN dotnet build "Lancet.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Lancet.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lancet.API.dll"]