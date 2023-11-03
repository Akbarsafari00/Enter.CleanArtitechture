FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ECA.Presentation.Api/ECA.Presentation.Api.csproj", "ECA.Presentation.Api/"]
RUN dotnet restore "ECA.Presentation.Api/ECA.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/ECA.Presentation.Api"
RUN dotnet build "ECA.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECA.Presentation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECA.Presentation.Api.dll"]
