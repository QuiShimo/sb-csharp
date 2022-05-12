List<int> numbers = new List<int>();

Random random = new Random();

for(int i = 0; i < 100; i++)
    numbers.Add(random.Next(0, 101));

PrintList(numbers);

for (int i = 99; i > 0; i--)
    if (numbers[i] > 25 && numbers[i] < 50) numbers.RemoveAt(i);

PrintList(numbers);

void PrintList(List<int> numbers)
{
    foreach(int num in numbers)
        Console.Write($"{num} ");

    Console.WriteLine();
}