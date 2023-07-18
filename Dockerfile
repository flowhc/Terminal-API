FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Terminal-API/Terminal-API.csproj", "Terminal-API/"]
RUN dotnet restore "Terminal-API/Terminal-API.csproj"
COPY . .
WORKDIR /src/Terminal-API
RUN dotnet build "Terminal-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Terminal-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "Terminal-API.dll"]
