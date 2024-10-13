# Address Standardization Service

���� ������ ������������ ����� ���-API ��� �������������� �������, ������������ Dadata API ��� ������� � ��������� �������.

## ����������

- ASP.NET Core
- Serilog ��� �����������
- AutoMapper ��� �������� ��������
- Dadata API ��� ������� �������

## ��������� �������
- AddressStandartizationService
  - Controllers
  - Interfaces
  - Models
  - Services

## ���������

-git clone https://github.com/ElizzavetaStrelnikova/AddressStandartizationApp.git
-cd AddressStandartizationApp
-���������� ����������� ������

-��������� ������ Dadata � ����� appsettings.json � ������ ������� API:
    "Dadata": {
        "ApiKey": "your_api_key",
        "SecretKey": "your_secret_key",
        "Accept": "application/json",
        "Content-Type": "application/json",
        "Url": "https://cleaner.dadata.ru/api/v1/clean/address"
    }

-��������� ������
-����� ������� ������� API ����� �������� �� ������ https://localhost:44350/index.html