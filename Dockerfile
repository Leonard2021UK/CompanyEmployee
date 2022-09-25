# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CompanyEmployee/*.csproj ./CompanyEmployee/
COPY Contracts/*.csproj ./Contracts/
COPY Entities/*.csproj ./Entities/
COPY LoggerService/*.csproj ./LoggerService/
COPY Repository/*.csproj ./Repository/
#RUN for file in $(ls ./*/*.csproj); do mkdir -p ${file%.*}/ && mv $file src/${file%.*}/; done
RUN dotnet restore

# copy everything and restore as distinct layers
COPY CompanyEmployee/. ./CompanyEmployee
COPY Contracts/. ./Contracts
COPY Entities/. ./Entities
COPY LoggerService/. ./LoggerService
COPY Repository/. ./Repository
WORKDIR /source
RUN dotnet publish -c release -o /app

## build app
#WORKDIR /source/CompanyEmployee
#RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet","CompanyEmployee.dll"]

