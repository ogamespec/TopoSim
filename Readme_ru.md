# TopoSim

Симулятор транзисторных схем на базе картинок топологии микросхемы.

![TopoSimLatest](/imgstore/TopoSimLatest.png)

<картинка концепта>

Разработка симулятора будет производится своего рода "волнами" или слоями (Layer). После имплементации каждого слоя будут реализованы какие-то полезные фичи, которые сам по себе уже можно как-то применять.

Все вышележащие слои зависят от нижележащих, поэтому такая организация.

## Layer0

Скелет приложения.

## Layer1

Набор слоёв (изображения формата .png например), представляющие собой собственно топологию микросхемы, а также JSON определённого формата, с дополнительной информацией о топологии:
- Типы слоёв (металл, диффузия и проч.)
- Параметр lambda задаёт погрешность, а также minimum feature size (по сути - метрику)
- Цвета (чтобы отфильтровать только актуальные пиксели слоя)
- Прочее

## Layer2

Картинки топологии трансформируются в сегменты. Сегмент - это прямоугольный участок топологии, в лямбда-метрике. Задачей сегментирования является преобразование битмапа со слоями сложной формы в стыкующиеся сегменты. Работать с сегментами проще и быстрее, чем с пикселями.

Можно сохранить сегментированные картинки в целях отладки. Сегментированные картинки могут отличаться от исходной топологии, т.к. будут отброшены области, которые меньше метрики.

Дополнительно на этом слое можно делать разные вспомогательные вещи, типа автовыравнивания виасов, спрямление проводов и проч.

## Layer3

Сегменты трансформируются в нетлист (провода и транзисторы). Между проводами устанвливается соответствие, чтобы можно было например выделить один провод, который представлен несколькими сегментами маски.

В качестве отладки нетлист сохраняется в редуцированный Verilog, который содержит только провода (wire) и транзисторы (модули типа nfet/pfet).

## Стадии разработки

- Layer1: Научиться грузить картинки и парсить JSON (тривиально)
- Layer2: Преобразовать картинки каждого слоя в список сегментов (`List<Segment>`); Сделать контрол для отображения сегментов; Возможность подсветки или выделения каким-то образом сегмента особыми цветами: 0, 1, z, x (для симуляции)
- Layer3: Создать из сегментов нетлист; Симуляция нетлиста (обход графа); Модуль для поиска проводов (Edges); Модуль для поиска транзисторов (Nodes)
- Layer4 (пока не будет): Находить в нетлисте более сложные модули (nor/nand) и симулировать их целиком, для ускорения

## Как происходит симуляция

- Производится обход всего графа (нетлиста)
- При заходе в Node работает модель nfet/pfet
- Обход производится до тех пор, пока старые значения Node/Edge не равны новым значениями Node/Edge ("стабилизация" схемы)
- У каждого Node/Edge есть счётчик стабилизации (propagation counter). Можно использовать для отображения тепловой карты распространения сигналов