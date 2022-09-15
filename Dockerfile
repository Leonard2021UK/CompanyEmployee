# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
RUN cd .. && ls -la
COPY *.sln .
COPY CompanyEmployee/*.csproj ./CompanyEmployee/
RUN dotnet restore

# copy everything and restore as distinct layers
COPY . ./CompanyEmployee
WORKDIR /source/CompanyEmployee
RUN dotnet publish -c release -o /app --no-restore

## build app
#WORKDIR /source/CompanyEmployee
#RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
RUN cd .. && ls -la
ENTRYPOINT ["dotnet", "app/CompanyEmployee.dll"]
