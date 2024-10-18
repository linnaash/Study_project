# используем образ с платформой .NET 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# открываем порт 80 для доступа к веб-приложению
EXPOSE 80

# сообщаем приложению о том, какой используется порт
ENV ASPNETCORE_URLS=http://+:80

# если нужно, чтобы при работе веб-приложния отображалась страница Swagger
ENV ASPNETCORE_ENVIRONMENT=Development

# устанавливаем рабочую папку, где будет размещаться приложение
WORKDIR /app

# используем образ с .NET SDK 6.0 для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

#устанавливаем рабочую папку, где будет происходить сборка проекта
WORKDIR /Cultura
# было /Cultura


# перемещаем конфигурационные файлы проекта в данный образ
COPY ["Cultura/Cultura-Test.csproj", "Cultura/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]

# выполняем восстановление зависимостей (nuget-пакетов) для проекта
RUN dotnet restore "Cultura/Cultura-Test.csproj"

# копируем все файлы из текущей папки на локальном компьютере в контейнер
COPY . .

FROM build AS publish
RUN dotnet publish "Cultura/Cultura-Test.csproj" -c Release -o /app/publish /p:UseAppHost=false

# используем образ для запуска уже собранного приложения
FROM base AS final

# устанавливаем рабочую папку для конечного запуска приложения
WORKDIR /app

# Копируем результаты сборки (опубликованное приложение) из этапа publish в рабочую директорию
COPY --from=publish /app/publish .

# Определяем точку входа в приложение - запускаем его с помощью команды dotnet и указанием dll-файла
ENTRYPOINT ["dotnet", "Cultura-Test.dll"]