#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

ENV PATH_TO_CSPROJ=walking-skeleton/walking-skeleton/Musika/Musika.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [${PATH_TO_CSPROJ}, "Musika/"]
RUN dotnet restore "Musika/Musika.csproj"
#COPY . .
WORKDIR "/src/Musika"
COPY . .
RUN dotnet build "Musika.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Musika.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["walking-skeleton/walking-skeleton/Musika/appsettings.json", "appsettings.json"]
ENTRYPOINT ["dotnet", "Musika.dll"]