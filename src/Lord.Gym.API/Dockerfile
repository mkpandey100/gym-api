#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80	
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Lord.Gym.API/Lord.Gym.API.csproj", "src/Lord.Gym.API/"]
COPY ["src/Lord.Gym.Application/Lord.Gym.Application.csproj", "src/Lord.Gym.Application/"]
COPY ["src/Lord.Gym.Domain/Lord.Gym.Domain.csproj", "src/Lord.Gym.Domain/"]
COPY ["src/Lord.Gym.Infrastructure/Lord.Gym.Infrastructure.csproj", "src/Lord.Gym.Infrastructure/"]
COPY ["src/shared/Lord.Core.API/Lord.Core.API.csproj", "src/shared/Lord.Core.API/"]
COPY ["src/shared/Lord.Core.SignalR/Lord.Core.SignalR.csproj", "src/shared/Lord.Core.SignalR/"]
RUN dotnet restore "src/Lord.Gym.API/Lord.Gym.API.csproj"
COPY . .
WORKDIR "/src/src/Lord.Gym.API"
RUN dotnet build "Lord.Gym.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lord.Gym.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lord.Gym.API.dll"]