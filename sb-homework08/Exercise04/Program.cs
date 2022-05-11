using System.Xml.Linq;


// создаем документ xml
XDocument xDoc = new XDocument();

// создаем элемент записной книжки
XElement person = new XElement("Person");

// добавляем атрибут name
Console.Write("Введите ФИО человека: ");
XAttribute personName = new XAttribute("name", Console.ReadLine());
person.Add(personName);

// Добавляем адрес
Console.WriteLine("Укажите адрес человека");
XElement address = new XElement("Address");

// запрашиваем и добавляем улицу
Console.Write("Введите улицу: ");
XElement street = new XElement("Street", Console.ReadLine());
address.Add(street);

// запрашиваем и добавляем номер дома
Console.Write("Введите номер дома: ");
XElement houseNumber = new XElement("HouseNumber", Console.ReadLine());
address.Add(houseNumber);

// запрашиваем и добавляем номер дома
Console.Write("Введите номер квартиры: ");
XElement flatNumber = new XElement("FlatNumber", Console.ReadLine());
address.Add(flatNumber);

// добавляем адрес
person.Add(address);

// информация о телефонах
XElement phones = new XElement("Phones");

// мобильный
Console.Write("Введите номер мобильного телефона: ");
XElement mobile = new XElement("MobilePhone", Console.ReadLine());
phones.Add(mobile);

// домашний
Console.Write("Введите номер домашнего телефона: ");
XElement flatPhone = new XElement("FlatPhone", Console.ReadLine());
phones.Add(mobile);

// Добавляем информацию о телефонах
person.Add(phones);

// добавляем элементы в документ
xDoc.Add(person);

// сохраняем документ
xDoc.Save("info.xml");