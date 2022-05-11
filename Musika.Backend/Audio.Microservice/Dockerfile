#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Musika.Backend/Audio.Microservice/Audio.Microservice.csproj", "Audio.Microservice/"]
RUN dotnet restore "Audio.Microservice/Audio.Microservice.csproj"
COPY . .
WORKDIR "/src/Audio.Microservice"
RUN dotnet build "Audio.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Audio.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Audio.Microservice.dll"]