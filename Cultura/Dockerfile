FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cultura/Cultura-Test.csproj", "Cultura/"]
RUN dotnet restore "Cultura/Cultura-Test.csproj"
COPY . .
WORKDIR "/src/Cultura"
RUN dotnet publish "Cultura-Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Cultura-Test.dll"]
