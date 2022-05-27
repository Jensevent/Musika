#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EF_App.csproj", "EF_App/"]
RUN dotnet restore "EF_App/EF_App.csproj"
WORKDIR "/src/EF_App"
COPY . .
RUN dotnet build "EF_App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EF_App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EF_App.dll"]