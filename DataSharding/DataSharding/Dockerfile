#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataSharding/DataSharding.csproj", "DataSharding/"]
RUN dotnet restore "DataSharding/DataSharding.csproj"
COPY . .
WORKDIR "/src/DataSharding"
RUN dotnet build "DataSharding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataSharding.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataSharding.dll"]