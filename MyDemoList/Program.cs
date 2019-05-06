using System;

namespace MyDemoList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(123);
            list.Add(738);
            list.Add(193);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
