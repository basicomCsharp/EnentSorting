
ReadConsol rc = new ReadConsol();
ReadConsol.ReadFromConsol();
rc.NumberEnterEvent += Sorting;
rc.InputNumberFromSort();
Console.ReadKey();

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

public  class ReadConsol
{
    //public delegate void SortFamilyDelegate(List<String> fs);
    public delegate void NumberEnterDelegate(int i);
    public event NumberEnterDelegate NumberEnterEvent;
    public static List<String> Family = new List<String>();

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
    public void InputNumberFromSort()
    {
        try
        {
            Console.WriteLine("Введите 1 для сортировки фамилий по алфавиту или 2 в обратном порядке");
            var FlagSort = Convert.ToInt16( Console.ReadLine());
            EventRun(FlagSort);
        }
        catch
        {
        }
    }
    protected virtual void EventRun(int num)
    {
        NumberEnterEvent?.Invoke(num);
    }


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
