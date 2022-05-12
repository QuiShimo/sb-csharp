## Что входит в задание
- [Задание 1. Работа с листом.](#задание-1-работа-с-листом)
- [Задание 2. Телефонная книга.](#задание-2-телефонная-книга)
- [Задание 3. Проверка повторов.](#задание-3-проверка-повторов)
- [Задание 4. Записная книжка.](#задание-4-записная-книжка)
 

## Задание 1. Работа с листом.
### Что нужно сделать
- Создайте лист целых чисел. 
- Заполните лист 100 случайными числами в диапазоне от 0 до 100. 
- Выведите коллекцию чисел на экран. 
- Удалите из листа числа, которые больше 25, но меньше 50. 
- Снова выведите числа на экран. 

### Что оценивается
- В программе используется три отдельных метода. 
- В качестве хранилища данных используется List.

## Задание 2. Телефонная книга.
### Что нужно сделать
Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца. Таким образом, у одного владельца может быть несколько номеров телефонов. Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
Далее программа предлагает найти владельца по введенному номеру телефона. Пользователь вводит номер телефона и ему выдаётся ФИО владельца. Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.

### Что оценивается
- Программа разделена на логические методы.
- Для хранения элементов записной книжки используется Dictionary.

## Задание 3. Проверка повторов.
### Что нужно сделать
Пользователь вводит число. Число сохраняется в HashSet коллекцию. Если такое число уже присутствует в коллекции, то пользователю на экран выводится сообщение, что число уже вводилось ранее. Если числа нет, то появляется сообщение о том, что число успешно сохранено. 

### Что оценивается
- В программе в качестве коллекции используется HashSet.

## Задание 4. Записная книжка.
### Что нужно сделать
Программа спрашивает у пользователя данные о контакте:
* ФИО
* Улица
* Номер дома
* Номер квартиры
* Мобильный телефон
* Домашний телефон

С помощью XElement создайте xml файл, в котором есть введенная информация. XML файл должен содержать следующую структуру:
```
<Person name=”ФИО человека” >
    <Address>
        <Street>Название улицы</Street>
        <HouseNumber>Номер дома</HouseNumber>
        <FlatNumber>Номер квартиры</FlatNumber>
    </Address>
    <Phones>
        <MobilePhone>89999999999999</MobilePhone>
        <FlatPhone>123-45-67<FlatPhone>
    </Phones>
</Person>
```

### Что оценивается
Программа создаёт Xml файл, содержащий все данные о контакте.