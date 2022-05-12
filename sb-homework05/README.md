# Практическая работа №5 Skillbox

## Что входит в задание
- [Задание 1. Метод разделения строки на слова.](#задание-1-метод-разделения-строки-на-слова)
- [Задание 2. Перестановка слов в предложении.](#задание-2-перестановка-слов-в-предложении)


## Задание 1. Метод разделения строки на слова.
### Что нужно сделать
Пользователь вводит в консольном приложении длинное предложение. Каждое слово в этом предложении отделено одним пробелом. Необходимо создать метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов. После вызова данного метода программа вызывает второй метод, который выводит каждое слово в отдельной строке.   

### Что оценивается
В программе, помимо основного метода main, присутствует два других метода, которые вызываются в теле метода main. 
Названием методов соответствуют тому, что они делают (разделяют или выводят данные).


## Задание 2. Перестановка слов в предложении.
### Что нужно сделать
Пользователь вводит в программе длинное предложение. Каждое слово раздельно одним пробелом. После ввода пользователь нажимает клавишу Enter. Необходимо создать два метода:

* первый метод разделяет слова в предложении;
* второй метод меняет эти слова местами (в обратной последовательности). 

При этом важно учесть, что один метод вызывается внутри другого метода, то есть в методе main вызывается метод cо следующей сигнатурой — ReversWords (string inputPhrase). Внутри этого метода вызывается метод по разделению входной фразы на слова.

### Что оценивается
Вызов метода по разделению на слова происходит внутри метода, который отвечает непосредственно за инвертирование слов в предложении.