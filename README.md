# Спільний проєкт лабораторної роботи

## Склад команди та завдання

### Учасники:

a) Кульчицький Віталій (PartA & Source);

b) Линник Ярослав (PartB);

c) Сухобрус Антон (PartC).

### Блок 1 варіанти (відповідно до списку учасників):

a) 10;

b) 5;

c) 1.

### Блок 2 (без варіантів):

Індивідуальна реалізація кожного з учасників.

### Блок 3 варіанти (відповідно до списку учасників):

a) 14; 

b) 11;

c) 13.

### Блок 4 варіанти (відповідно до списку учасників):

a) 3; 

b) 15;

c) 4.

## Умови завдань

### Блок 1

10 - Знищити всі елементи між першим із мінімальних за значенням і останнім із максимальних за значенням; самі перший з мінімальних та останній з максимальних лишити (не знищувати); врахувати, що невідомо, який з них записано в масиві раніше.

5 - Знищити T елементів, починаючи з номеру К (якщо, починаючи з номера К, елементи є, але менше, чим T штук — знищити, скільки є; однак, якщо К від'ємне, не робити нічого).

1 - Знищити перший парний елемент.

### Блок 2

2а) Прочитайте єдине натуральне число n, спочатку сформуйте у пам'яті у вигляді зубчастого масиву з
рядками різної довжини, потім виведіть на екран такі переліки: для кожного i від 0 до n–1, послідовність
номер i містить, у порядку зростання, ті й тільки ті числа від 1 до n, які кратні сумі цифр числа i.

2б) Результат виведення на екран повинен бути абсолютно таким самим, як у попередньому пункті, але в
пам'яті повинно бути значно менше різних «вкладених» одновимірних масивів, за рахунок того, що різні
числа можуть мати однакову суму цифр, у цих випадках виходить однакова послідовність, і її можна
тримати в пам'яті один раз.

Проведіть вимірювання технічними засобами обсягів використаної пам'яті в кожному з цих варіантів
пам'яті і проаналізуйте це своїми словами.

### Блок 3

14 - Додати рядок перед рядком, що містить найменший елемент (якщо у різних місцях є кілька елементів з однаковим мінімальним значенням, то брати перший з них).

11 - Додати по одному рядку після кожного парного рядка матриці (тобто, кожного рядка, що у початковій матриці мав парний номер).

13 - Додати рядок перед рядком, що містить найбільший елемент (якщо у різних місцях є кілька елементів з однаковим максимальним значенням, то брати останній з них).

### Блок 4

3 - Кожен рядок матриці A на першій і останній позиції містить індекси відповідно початку і кінця діапазону елементів рядка, які необхідно переписати у відповідний рядок матриці B. Створити матрицю B з необхідною кількістю стовпчиків у кожному рядку та переписати до неї вказані елементи з матриці A. Відсортувати кожен рядок матриці A за зростанням.

15 - Задані два одновимірні масиви однакової довжини: R і S. Сформувати квадратну матрицю A, кожен елемент якої, що знаходиться в i-му рядку та j-му стовпчику, дорівнює сумі елементів масива R на позиції i та масива S на позиції j. Транспонувати матрицю A та інвертувати порядок елементів кожного її рядка, після чого поміняти місцями перший і останній рядок.

4 - Одновимірний масив Z послідовно заповнити збільшеними на одиницю індексами останніх нулів у кожному рядку матриці P (якщо у деякому рядку матриці нулі відсутні, у масив записати число, що дорівнює кількості стовпчиків у матриці P). Створити матрицю Q, кількість стовпчиків якої у кожному рядку дорівнює відповідному значенню в Z, заповнити її випадковими числами та відсортувати кожен рядок за зменшенням.

## Блок схема спільної частини

![blockSheme](https://media.discordapp.net/attachments/764942712054743080/959800415640231986/L2Cooperative_Main_blockSheme.png?width=1080&height=310)
