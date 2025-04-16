FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY JokesApi.sln ./

RUN mkdir -p JokesApi
RUN mkdir -p JokesApi_BAL
RUN mkdir -p JokesApi_DAL

COPY ./JokesApi/*.csproj ./JokesApi/
COPY ./JokesApi_BAL/*.csproj ./JokesApi_BAL/
COPY ./JokesApi_DAL/*.csproj ./JokesApi_DAL/

RUN dotnet restore

COPY . .

RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "JokesApi.dll"]
