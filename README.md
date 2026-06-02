# SystemObserver

### Высокопроизводительный сервис системного мониторинга

![Build Status](https://img.shields.io/github/actions/workflow/status/MChuvilevM/SystemObserverService/ci.yml?branch=main&label=Build)
![.NET 9](https://img.shields.io/badge/.NET-9.0-blue)
![License](https://img.shields.io/github/license/MChuvilevM/SystemObserverService)

---

## 🏗 Архитектура

Проект построен на принципах **Clean Architecture**, обеспечивая строгую изоляцию бизнес-логики от реализации инфраструктуры.

| Слой | Ответственность |
| :--- | :--- |
| **Domain** | Ядро: модели и интерфейсы |
| **Application** | Бизнес-логика: обработка и трансформации |
| **Infrastructure** | Реализация: работа с файловой системой |
| **Worker** | Точка входа: фоновый хост и конфигурация |

---

📂 Структура проекта

.
├── src/
│   ├── SystemObserver.Application/   # Логика обработки
│   ├── SystemObserver.Domain/        # Бизнес-модели
│   ├── SystemObserver.Infrastructure/# Работа с данными
│   └── SystemObserver.Worker/        # Хостинг-сервис
├── tests/                            # Тестовый набор
└── .github/workflows/                # CI-пайплайны

---

⚙️ Настройка

Конфигурация параметров сбора метрик производится в файле appsettings.json:

{
  "MetricSettings": {
    "StoragePath": "metrics.log",
    "IntervalSeconds": 10
  }
}

StoragePath: Путь к файлу логов.

IntervalSeconds: Частота опроса системы (секунды).

---

🚀 Запуск

Сборка проекта: dotnet build

Запуск сервиса: dotnet run --project src/SystemObserver.Worker

  Разработано с использованием .NET 9.0

---  
  Автор: MChuvilevM
---
