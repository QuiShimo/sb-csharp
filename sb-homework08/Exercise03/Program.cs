HashSet<int> hs = new HashSet<int>();
int number;

while (true)
{
    Console.Write("Введите число: ");
    if (Int32.TryParse(Console.ReadLine(), out number))
    {
        if (hs.Add(number))
        {
            Console.WriteLine("Число успешно добавлено!");
        }
        else
        {
            Console.WriteLine("Число уже есть в коллекции");
        }
    }
    else
    {
        Console.WriteLine("Ошибка! Повторите ввод числа.");
    }
}