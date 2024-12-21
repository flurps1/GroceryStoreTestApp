# Grocery Store App

## Описание проекта
 **Grocery Store App** — это тестовое задание для продуктового магазина. Приложение позволяет пользователям ознакомиться с ассортиментом магазина и собрать себе корзину из овощей и фруктов.

## Используемые технологии
- **AvaloniaUI**
- **MVVM Community Toolkit**
- **Microsoft.Extensions.DependencyInjection**

- ## Запуск приложения:
1. **Установите зависимости**:
   ```bash
   dotnet restore
2. **Соберите проект**:
   ```bash
   dotnet build
3. **Запустите приложение**:
   ```bash
   dotnet run
## Тестирование:
- **Для эмуляции API и проверки взаимодействий используется Mockoon. Запустите Mockoon и настройте endpoint для получения списка товаров**.
```bash
[
  {
    "IconPath": "avares://SampleTestApp.Core/Assets/png/banana.png",
    "Name": "Бананы",
    "Quantity": 10
  },
  {
    "IconPath": "avares://SampleTestApp.Core/Assets/png/apple.png",
    "Name": "Яблоки",
    "Quantity": 20
  },
  {
    "IconPath": "avares://SampleTestApp.Core/Assets/png/pear.png",
    "Name": "Груши",
    "Quantity": 30
  },
  {
    "IconPath": "avares://SampleTestApp.Core/Assets/png/tomato.png",
    "Name": "Помидоры",
    "Quantity": 40
  }
]
```
## Api:
**Добавлен backend** : [GroceryStoreTestApp.Api](https://github.com/flurps1/GroceryStoreTestApp.Api). 
