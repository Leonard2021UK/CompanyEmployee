﻿# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy everything and restore as distinct layers
COPY . .
RUN ls -la
RUN dotnet restore
RUN dotnet --version
# build app
WORKDIR /source/CompanyEmployee
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
RUN cd .. && ls -la
ENTRYPOINT ["dotnet", "CompanyEmployee.dll"]
