using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BaseballGame
{

    class SameNumberException : Exception
    {
        public SameNumberException() { }
    }

    class Program
    {
        
        static double WinRate(int count, int stack)
        {
            double winRate = (double)stack / count * 100;
            winRate = Math.Round(winRate, 2);
            return winRate;
        }
        static void Main(string[] args)
        {
            int[] answer = new int[3] { 0, 0, 0 };
            int[] inputArray = new int[3];
            string input = "0";
            int inputNumber = 0;
            Random rand = new Random();
            bool retry = true;
            int count = 0;
            int winStack = 0;
            int playCount = 0;

            do
            {
                Console.WriteLine("야구게임입니다. 1~9 까지의 숫자를 맞혀주세요!");
                Console.WriteLine("10회 안에 맞추셔야 합니다.");

                for (int i = 0; i < answer.Length; i++)
                {
                    int temp = rand.Next(1, 10);
                    for (int j = 0; j < answer.Length; j++)
                    {
                        if (answer[j] == temp)
                        {
                            temp = rand.Next(1, 10);
                            j--;
                        }
                    }
                    answer[i] = temp;
                }

                do
                {
                    Console.Write("{0}번째 입력 : ", count + 1);
                    try
                    {
                        checked
                        {
                            inputNumber = int.Parse(Console.ReadLine());
                        }
                        //if (inputNumber < 100 || inputNumber > 999)
                        //{
                        //    throw new Exception();
                        //}
                        input = inputNumber.ToString();
                        for (int i = 2; i > -1; i--)
                        {
                            int.TryParse(input.Substring(i), out inputArray[i]);
                            input = input.Substring(0, input.Length - 1);
                        }
                        if (inputArray[0] == inputArray[1] || inputArray[0] == inputArray[2] || inputArray[1] == inputArray[2])
                        {
                            throw new SameNumberException();
                        }
                    }

                    catch (SameNumberException)
                    {
                        MessageBox.Show("서로 다른 숫자를 입력해주세요!", "입력 오류");
                        continue;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("1~9까지의 세자리 숫자를 입력해주세요!", "입력 오류");
                        continue;
                    }

                    count++;
                    int ball = 0;
                    int strike = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (inputArray[i] == answer[i])
                            strike++;
                        else if (inputArray[i] == answer[0] || inputArray[i] == answer[1] || inputArray[i] == answer[2])
                            ball++;
                    }
                    if (strike == 3)
                    {
                        Console.WriteLine("정답입니다!");
                        Console.WriteLine("{0}회만에 맞추셨습니다.", count);
                        winStack++;
                        retry = false;
                        ball = 0;
                        strike = 0;
                    }
                    else
                    {
                        Console.WriteLine("==> {0}스트라이크 {1}볼", strike, ball);
                        ball = 0;
                        strike = 0;
                    }
                    if (retry == true && count == 10)
                    {
                        Console.WriteLine("실패했습니다.정답은 {0}{1}{2} 입니다.", answer[0], answer[1], answer[2]);

                        retry = false;
                    }
                } while (retry);
                playCount++;

                Console.WriteLine("승률 : {0}%", WinRate(playCount, winStack));
                Console.WriteLine("다시 시도하시겠습니까? 1.예 2.아니오");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    count = 0;
                    retry = true;
                }
            } while (retry);
        }
    }
}
