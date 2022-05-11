Dictionary<string, string> phoneBook = new Dictionary<string, string>();

//ввод данных
InputData(phoneBook);
// поиск по номеру телефона
SearchData(phoneBook);


/// <summary>
/// Ввод данных в телефонную книгу
/// </summary>
/// <param name="phoneBook">Телефонная книга</param>
static void InputData(Dictionary<string, string> phoneBook)
{
    string phoneNumber;
    string fullName;

    while (true)
    {
        Console.Write("Введите номер телефона: ");
        phoneNumber = Console.ReadLine();

        if (phoneNumber == "")
        {
            Console.WriteLine("Ввод данных завершен");
            break;
        }

        Console.Write("ВВедите ФИО владельца: ");
        fullName = Console.ReadLine();

        if (phoneBook.TryAdd(phoneNumber, fullName))
        {
            Console.WriteLine("Запись успешно добавлена");
        }
        else
        {
            Console.WriteLine("Данный телефон уже есть в телефонной книге");
        }
    }
}

/// <summary>
/// Поиск данных в телефонной книге
/// </summary>
/// <param name="phoneBook">Телефонная книга</param>
static void SearchData(Dictionary<string, string> phoneBook)
{
    string searchRezult;


    Console.Write("Введите номер телефона для поиска: ");
    string searchPhoneNumber = Console.ReadLine();

    if (phoneBook.TryGetValue(searchPhoneNumber, out searchRezult))
    {
        Console.WriteLine($"Номер телефона найден! Владелец: {searchRezult}");
    }
    else
    {
        Console.WriteLine("Номер телефона не найден!");
    }
}