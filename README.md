# ApiKurs
## Приложение для курсового проекта

## Особенности

- Работа в автоматическом режиме
- Работа в трее
- Использование сторонних библиотек и API

Задача приложения: отслеживание времени проезда в автоматическом режиме, 4 раза в день, 
по указанным координатам начала и конца маршрута.

## Технологии

- Quartz - Библиотека для работы со временем
- API Bing Maps - Построение маршрутов по координатам
- Newtonsoft JSON - Библиотека для работы с JSON

## Функции
- Exit - закрытие программы
- Start Now - произвести замер времени в данный момент
- Start automatically - замеры проводятся в автоматическом режиме в 00:00, 06:00, 12:00, 18:00
- Stop - остановка автоматических замеров, без выхода из программы
- Set time - установить время замеров
- Set coordinates - открыть форму ввода координат маршрутов
- Get output - открыть файл с выводом данных

## Использование

После запуска программа находится в трее, управление происходит через контекстное меню, вызываемое нажатием правой кнопки мыши. Список координат между точками вводится попарно, в текстовый файл "coordinates.txt", ответ выводится в файл "output.txt" в виде: время проезда между точками в секундах, дата замеров, время замеров.