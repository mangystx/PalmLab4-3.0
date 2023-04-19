using PalmLab4;

while (true)
{
    Console.WriteLine("Введіть номер завдання");
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Введіть довжину одновимірного масиву");
            int[] arr = new int[int.Parse(Console.ReadLine())];
            Console.WriteLine("Введіть цифру відповідну способу " +
                              "введення одновимірного масиву:\n" +
                              "1 Заповнення випадковими числами\n" +
                              "2 Заповення в рядок\n3 Заповнення в стовпчик");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введіть мінімальне та максимальне допустимі значення через пропуск -> ");
                    int[] bord = (from num in Console.ReadLine().Trim().Split() select int.Parse(num)).ToArray();
                    arr = Fillting.FillArrayWithRandom(arr, bord.Min(), bord.Max());
                    Console.WriteLine($"Ваш масив: {String.Join(", ", arr)}\n");
                    break;
                case "2":
                    arr = Fillting.FillArrayFromConsoleWithSpace(arr);
                    break;
                case "3":
                    arr = Fillting.FillArrayFromConsoleWithEnter(arr);
                    break;
                default:
                    Console.WriteLine("Видалення папки System32 через: 3");
                    Thread.Sleep(1000);
                    Console.WriteLine("2");
                    Thread.Sleep(1000);
                    Console.WriteLine("1");
                    Thread.Sleep(1000);
                    Console.WriteLine("BB братик\nЦе ШД-шка");
                    break;
            }

            bool blockOneGo = true;
            while (blockOneGo)
            {
                ChooseYourChampionBlock1(ref arr);
                Console.WriteLine("Ведіть q якщо не бажаєте передати щойно опрацьований масив в метод іншого учня," +
                                  " в іншому випадку натисніть enter");
                if (String.Compare("q", Console.ReadLine(), StringComparison.OrdinalIgnoreCase) == 0)
                {
                    blockOneGo = false;
                }
            }

            break;
        case "2":
            int[][] jagArr = GetJagArr();
            bool blockTwoGo = true;
            while (blockTwoGo)
            {
                ChooseYourChampionBlock2(ref jagArr);
                Console.WriteLine("Ведіть q якщо не бажаєте передати щойно опрацьований масив в метод іншого учня," +
                                  " в іншому випадку натисніть enter");
                if (String.Compare("q", Console.ReadLine(), StringComparison.OrdinalIgnoreCase) == 0)
                {
                    blockTwoGo = false;
                }
            }
            
            break;
        case "3":
            bool blockThreeGo = true;
            while (blockThreeGo)
            {
                Console.WriteLine("Введіть цифру відповідну номеру учня\n" +
                                  "1 Марченко А.І.\n2 Каюк І.В.\n" +
                                  "3 Мартиненко О.С.\n4 Шафієв Д.Ю.");
                switch (Console.ReadLine())
                {
                    case "1":
                        int[][] matrix = GetJagArr();
                        ChooseYourChampionBlock3(ref matrix, 1);
                        break;
                    case "2":
                        int[][] matrixIvan = GetJagArr();
                        ChooseYourChampionBlock3(ref matrixIvan, 2);
                        break;
                    case "3":
                        Console.WriteLine("Введіть довжину першого зубчастого масиву");
                        int[][] matrixLexa1 = new int[int.Parse(Console.ReadLine())][];
                        
                        Console.WriteLine("Введіть довжину другого зубчастого масиву");
                        int[][] matrixLexa2 = new int[int.Parse(Console.ReadLine())][];
                        
                        Console.WriteLine("Введіть цифру відповідну способу " +
                                          "введення зубчастого масиву:\n" +
                                          "1 Заповнення випадковими числами\n" +
                                          "2 Заповення в рядок\n3 Заповнення в стовпчик");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Введіть мінімальне та максимальне допустимі значення через пропуск -> ");
                                int[] bord = (from num in Console.ReadLine().Trim().Split() select int.Parse(num)).ToArray();
                                matrixLexa1 = Fillting.FillJaggedArrayWithRandom(matrixLexa1, bord.Min(), bord.Max());
                                matrixLexa2 = Fillting.FillJaggedArrayWithRandom(matrixLexa2, bord.Min(), bord.Max());

                                Console.WriteLine("Ваш перший масив:");
                                PrintJagArr(matrixLexa1);
                                Console.WriteLine("Ваш друий масив"); 
                                PrintJagArr(matrixLexa2);
                                break;
                            case "2":
                                matrixLexa1 = Fillting.FillJaggedArrayWithSpace(matrixLexa1);
                                matrixLexa2 = Fillting.FillJaggedArrayWithSpace(matrixLexa2);
                                break;
                            case "3":
                                matrixLexa1 = Fillting.FillJaggedArrayFromConsoleWithEnter(matrixLexa1);
                                matrixLexa2 = Fillting.FillJaggedArrayWithSpace(matrixLexa2);
                                break;
                            default:
                                Console.WriteLine("Некоректне занчення,перехід до кейсу 1");
                                goto case "1";
                        }
                        Lexa.MainMethodBlock3(matrixLexa1,matrixLexa2);
                        break;
                    case "4":
                        int[,] VanArr;
                        Console.WriteLine("Введіть 1 для заповнення масиву через ентер аба 2 для заповнення через пробіл  ");
                        int choiceVan = int.Parse(Console.ReadLine());
                        Console.Write("Введіть кількість рядків  ");
                        int vanX = int.Parse(Console.ReadLine());
                        Console.Write("Введіть кількість стовпчиків  ");
                        int vanY = int.Parse(Console.ReadLine());
                        Console.WriteLine(@"Введіть 1 або 0 
break;");
                        switch (choiceVan)
                        {
                            case 1 :
                                VanArr = Fillting.FillArrayFromKeyboard(vanX, vanY);
                                int[][] res1 = VanDarckhoule.VanVol3(VanArr);
                                break;
                            case 2 :
                                VanArr = Fillting.FillArrayFromKeyboard2(vanX, vanY);
                                int[][] res2 = VanDarckhoule.VanVol3(VanArr);
                                // res1 = res2;
                                // res2 = res1;
                                // res1 = res1 == res1 ? res1 : res1;
                                // if (res1 == res1)
                                // {
                                //     Console.Write("");   
                                // }
                                //
                                // foreach (var noRes1 in res1)
                                // {
                                //     try
                                //     {
                                //         NullReferenceException n = new NullReferenceException();
                                //         throw n;
                                //     }
                                //     catch (NullReferenceException e)
                                //     {
                                //         
                                //     }
                                // }
                                
                                break;
                            default:
                                Console.WriteLine("Ви не ввели 1 або 2 тому вводіть через ентер");
                                goto case 1;
                                break;
                                break;
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Некоректне занчення");
                        break;
                }
                Console.WriteLine("Ведіть q якщо не бажаєте передати щойно опрацьований масив в метод іншого учня," +
                                  " в іншому випадку натисніть enter");
                if (String.Compare("q", Console.ReadLine(), StringComparison.OrdinalIgnoreCase) == 0)
                {
                    blockThreeGo = false;
                }
            }
            
            break;
    }

    Console.WriteLine("Якщо бажаєте вийти введіть q");
    if (string.Compare(Console.ReadLine(), "q", StringComparison.OrdinalIgnoreCase) == 0)
    {
        break;
    }
}

static void PrintJagArr(int[][] arr)
{
    foreach (var oneDimArr in arr)
    {
        Console.WriteLine(String.Join(", ", oneDimArr));
    }
}

static void ChooseYourChampionBlock1(ref int[] arr)
{
    Console.WriteLine("Введіть цифру відповідну номеру учня\n" +
                      "1 Марченко А.І.\n2 Каюк І.В.\n" +
                      "3 Мартиненко О.С.\n4 Шафієв Д.Ю.");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Введіть ключ -> ");
            arr = Billy.DeleteKey(arr, int.Parse(Console.ReadLine()));
            Console.WriteLine(string.Join(", ", arr));
            break;
        case "2":
            Ivan.Find_Even_One(ref arr);
            break;
        case "3":
            Lexa.MainMethodBlock1(arr);
            break;
        case "4":
            arr = VanDarckhoule.VanVol1(arr);
            break;
        default:
            Console.WriteLine("Некоректне занчення");
            break;
    }
}
static void ChooseYourChampionBlock2(ref int[][] arr)
{
    List<int[]> arrListVersion = new List<int[]>(arr.Length);
    foreach (var oneDimArr in arr)
    {
        arrListVersion.Add(oneDimArr);
    }

    Console.WriteLine("Введіть цифру відповідну номеру учня\n" +
                      "1 Марченко А.І.\n2 Каюк І.В.\n" +
                      "3 Мартиненко О.С.\n4 Шафієв Д.Ю.");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Введіть K -> ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Для того щоб виконати завдання з використанням list введіть 1," +
                              " для звичайного виконання введіть 2");
            switch (Console.ReadLine())
            {
                case "1":
                    Billy.AddKRowsInJagArrWithList(ref arrListVersion, k);
                    PrintJagArr(arrListVersion.ToArray());
                    break;
                case "2":
                    Billy.AddKRowsInJagArr(ref arr, k);
                    PrintJagArr(arr);
                    break;
                default:
                    Console.WriteLine("Некоректне значення, перехід до кейсу 2");
                    goto case "2";
            }
            break;
        case "2":
            Ivan.Extend_Mass(ref arr);
            break;
        case "3":
            Lexa.MainMethodBlock2(arr);
            break;
        case "4":
            arr = VanDarckhoule.VanVol2(arr);
            break;
        default:
            Console.WriteLine("Некоректне занчення");
            break;
    }
}

static void ChooseYourChampionBlock3(ref int[][] arr, int variant)
{
    switch (variant)
    {
        case 1:
            Console.WriteLine("Матриця B:");
            PrintJagArr(Billy.Block3(ref arr));
            Console.WriteLine("Матриця A:");
            PrintJagArr(arr);
            break;
        case 2:
            Ivan.Change_ZeroElement_With_MinElement(ref arr);
            break;
        default:
            Console.WriteLine("Ivo Bobulo?");
            break;
    }
}

static int[][] GetJagArr()
{
    Console.WriteLine("Введіть довжину зубчастого масиву");
    int[][] arr = new int[int.Parse(Console.ReadLine())][];
    Console.WriteLine("Введіть цифру відповідну способу " +
                      "введення зубчастого масиву:\n" +
                      "1 Заповнення випадковими числами\n" +
                      "2 Заповення в рядок\n3 Заповнення в стовпчик");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Введіть мінімальне та максимальне допустимі значення через пропуск -> ");
            int[] bord = (from num in Console.ReadLine().Trim().Split() select int.Parse(num)).ToArray();
            arr = Fillting.FillJaggedArrayWithRandom(arr, bord.Min(), bord.Max());
            Console.WriteLine("Ваш масив:");
            PrintJagArr(arr);
            break;
        case "2":
            arr = Fillting.FillJaggedArrayWithSpace(arr);
            break;
        case "3":
            arr = Fillting.FillJaggedArrayFromConsoleWithEnter(arr);
            break;
    }

    return arr;
}