# используемый образ (OS) + установленная платформа .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#открытие порта 80(используется по умолчанию для приема HTTP-запросов)
EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
#если нужно, чтобы отображалась страница Swagger
ENV ASPNETCORE_ENVIRONMENT Development

WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdc:8.0 AS build
WORKDIR /Cultura
COPY ["DataAccess/DataAccess.csproj","DataAcces/"]
COPY ["Domain\Domain.csproj","Domain/"]
COPY ["BusinessLogic\BusinessLogic.csproj","BusinessLogic/"]
COPY ["Cultura\Cultura-Test.csproj","Cultura/"]
RUN dotnet restore "Cultura\Cultura-Test.csproj"

COPY . .
FROM build AS publish
RUN dotnet publish "Cultura\Cultura-Test.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cultura-Test.dll"]
