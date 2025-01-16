FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyWeatherApp.csproj", "."]
RUN dotnet restore "MyWeatherApp.csproj"
COPY . .
RUN dotnet build "MyWeatherApp.csproj" -c Release -o /app/build
RUN dotnet publish "MyWeatherApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "MyWeatherApp.dll"]
