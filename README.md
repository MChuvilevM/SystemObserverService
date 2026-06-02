SystemObserver
Высокопроизводительный сервис системного мониторинга
🏗 Архитектура

Проект построен на принципах Clean Architecture, обеспечивая строгую изоляцию бизнес-логики от реализации инфраструктуры.
Слой	Ответственность
Domain	Ядро: модели (SystemMetric) и интерфейсы (IMetricRepository).
Application	Бизнес-логика: обработка и трансформации (MetricProcessor).
Infrastructure	Реализация: работа с файловой системой и ротация логов.
Worker	Точка входа: фоновый хост и конфигурация DI-контейнера.
📂 Структура проекта

.
├── src/
│   ├── SystemObserver.Application/   # Логика обработки
│   ├── SystemObserver.Domain/        # Бизнес-модели
│   ├── SystemObserver.Infrastructure/# Работа с данными
│   └── SystemObserver.Worker/        # Хостинг-сервис
├── tests/                            # Тестовый набор
└── .github/workflows/                # CI-пайплайны

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

🚀 Запуск

Сборка проекта: dotnet build

Запуск сервиса: dotnet run --project src/SystemObserver.Worker

  Разработано с использованием .NET 9.0

  Автор: MChuvilevM
