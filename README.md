# Address Standardization Service

Этот проект представляет собой веб-API для стандартизации адресов, использующее Dadata API для очистки и валидации адресов.

## Технологии

- ASP.NET Core
- Serilog для логирования
- AutoMapper для маппинга объектов
- Dadata API для очистки адресов

## Структура проекта
- AddressStandartizationService
  - Controllers
  - Interfaces
  - Models
  - Services

## Установка

- git clone https://github.com/ElizzavetaStrelnikova/AddressStandartizationApp.git
- cd AddressStandartizationApp
- Установите необходимые пакеты

- Наполните секцию Dadata в файле appsettings.json с вашими ключами API:
    "Dadata": {
        "ApiKey": "your_api_key",
        "SecretKey": "your_secret_key",
        "Accept": "application/json",
        "Content-Type": "application/json",
        "Url": "https://cleaner.dadata.ru/api/v1/clean/address"
    }

- Запустите проект
- После запуска проекта API будет доступно по адресу https://localhost:44350/index.html