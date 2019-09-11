using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0911
{
    class Program
    {

        static public string ForPrintString(int a)
        {
            if (a == 1)
                return "가위";
            if (a == 2)
                return "바위";
            else
                return "보";
        }

        static double WinRate(int count, int stack)
        {
            double winRate = (double)stack / count * 100;
            winRate = Math.Round(winRate, 2);
            return winRate;
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int select;
            int winStack = 0;
            int playCount = 0;
            bool retry = true;

            while (retry)
            {
                Console.WriteLine("1.가위  2.바위  3.보");
                Console.Write("선택 : ");
                select = int.Parse(Console.ReadLine());
                int computer = rand.Next(1, 4);
                Console.WriteLine("-----------------------------");
                Console.WriteLine("나) {0} : {1} (컴", ForPrintString(select), ForPrintString(computer));
                Console.Write("결과 : ");
                if (computer > select)
                {
                    if (computer != 3)
                        Console.WriteLine("졌습니다.");
                    else
                    {
                        Console.WriteLine("이겼습니다.");
                        winStack++;
                    }
                }
                else if (computer < select)
                {
                    if (computer == 1)
                        Console.WriteLine("졌습니다.");
                    else
                    {
                        Console.WriteLine("이겼습니다.");
                        winStack++;
                    }
                }
                else
                    Console.WriteLine("비겼습니다.");
                playCount++;
                Console.WriteLine("승률 : {0}%", WinRate(playCount, winStack));
                Console.WriteLine("계속하시겠습니까? 1.계속  2.종료");
                select = int.Parse(Console.ReadLine());
                if (select == 2)
                {
                    retry = false;
                }
            }
        }
    }
}