#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

COPY . ./
RUN dotnet publish "./ProWebbCore.Api/ProWebbCore.Api.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ProWebbCore.Api.dll"]

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["ProWebbCore.Api.csproj", "ProWebbCore.Api/"]
#RUN dotnet restore "ProWebbCore.Api/ProWebbCore.Api.csproj"
#COPY . ./
#WORKDIR "/src/ProWebbCore.Api"
#RUN dotnet build "ProWebbCore.Api.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ProWebbCore.Api.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProWebbCore.Api.dll"]