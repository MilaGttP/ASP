# Домашня робота з теми "Представлення. Часткові представлення. Компоненти представлень"

Використовуючи Visual Studio 202x, створіть проект за шаблоном ASP.NET MVC.

1. Додайте в проект представлення MyData та MyDataView
   
2. На сторінці MyData реалізуйте форму введення даних (Прізвище, Ім'я, По батькові, Стать (RadioButton),
    Місто випадаючий список (DropDownList), Хобі з множинним вибором (ListBox), Дата народження,
    Елемент управління кнопка - Надіслати).
    При натисканні елемента керування кнопка "Надіслати" автоматично переходимо на сторінку MyDataView і всі дані, введені на стор. MyData,
    повинні бути відображені на сторінці MyDataView у вигляді форматованого елемента (для відображення використовувати PartialView або ViewComponent).

Налаштувати маршрутизацію таким чином, щоб відразу (без введення імені контролера та методу) на екрані з'являлася сторінка MyData.
