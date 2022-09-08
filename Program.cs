
ReadConsol rc = new ReadConsol();
ReadConsol.ReadFromConsol();
rc.NumberEnterEvent += Sorting;
rc.InputNumberFromSort();
Console.ReadKey();
/// <summary>
/// Метод определения и вызова типа сортировки
/// </summary>
static void Sorting(int number)
{
    switch(number)
    {
        case 1:
            ReadConsol.AlfaSort();
            break;
        case 2:
            ReadConsol.OmegaSort();
            break;
        default:
            break;
    }
}
/// <summary>
/// Класс ввода и сортировки фамилий
/// </summary>
public  class ReadConsol
{    
    public delegate void NumberEnterDelegate(int i);
    public event NumberEnterDelegate NumberEnterEvent;
    public static List<String> Family = new List<String>();
    /// <summary>
    /// Метод ввода фамилий для коллекции
    /// </summary>
    public static void ReadFromConsol()
    {
        try
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите {0}-ю фамилию", i + 1);
                var str = Console.ReadLine();
                if (str != null)
                    Family.Add(str);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// Метод для ввода типа сортировки
    /// </summary>
    public void InputNumberFromSort()
    {
        try
        {
            Console.WriteLine("Введите 1 для сортировки фамилий по алфавиту или 2 в обратном порядке");
            var FlagSort = Convert.ToInt16( Console.ReadLine());
            EventRun(FlagSort);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// вызов события
    /// </summary>
    /// <param name="num"></param>
    protected virtual void EventRun(int num)
    {
        NumberEnterEvent?.Invoke(num);
    }

    /// <summary>
    /// Метод сортировки коллекции в обратном порядке
    /// </summary>
    public static void OmegaSort()
    {
        Family.Sort();
        Family.Reverse();
        Console.WriteLine("Результат сортировки в обратном порядке алфавиту");
        foreach (var f in Family)
        {
            Console.WriteLine(f);
        }
    }
    /// <summary>
    /// Метод сортировки коллекции по алфавиту
    /// </summary>
    public static void AlfaSort()
    {
        Family.Sort();
        Console.WriteLine("Результат сортировки по алфавиту");
        foreach (var f in Family)
        {
            Console.WriteLine(f);
        }
    }
}
