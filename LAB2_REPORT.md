# Лабораторная работа №2

## Реализовано

- ISP-интерфейсы `IMovable`, `IDrawable`, `IShape`, `I3DShape`, `IPayable`, `ILogger`.
- Обобщённый контракт `IRepository<T>` и специализированный `IUserRepository`.
- CRUD-репозиторий пользователей.
- JSON REST API для сущности `User`.

## REST API

| Метод | URL | Результат |
|---|---|---|
| GET | `/user` | список пользователей |
| GET | `/user/{id}` | пользователь или 404 |
| POST | `/user` | создание, 201 Created |
| PUT | `/user/{id}` | изменение, 204 No Content |
| DELETE | `/user/{id}` | удаление, 204 No Content |

Пример JSON для POST:

```json
{
  "name": "Иван Иванов",
  "email": "ivan@example.com"
}
```

## Проверка

Проект `SITE.csproj` успешно собирается командой `dotnet build` без ошибок и предупреждений.

## Вывод

В работе применены интерфейсы для разделения обязанностей, generic-репозиторий для повторного использования CRUD-логики и контроллер ASP.NET Core Web API для обмена данными в формате JSON.
