using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace PhoneBook_hashset_
{
    class MenuChoiceException : Exception
    {
        int wrongChoice;
        public MenuChoiceException() { }
        public MenuChoiceException(string message) : base(message) { }

        public MenuChoiceException(int choice) : base("다시 메뉴를 선택해주세요.")
        {
            wrongChoice = choice;
        }
        public void showWrongChoice()
        {
            Console.WriteLine(wrongChoice + "에 해당하는 메뉴는 존재하지 않습니다.");

        }
    }


    class PhoneBook
    {
        //public static int MAX_CNT = 5;
        //static PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        //static int cunCnt = 0;
        static HashSet<PhoneInfo> infoStorage = new HashSet<PhoneInfo>();
        static BinaryFormatter bf = new BinaryFormatter();
        //static FileInfo fw = new FileInfo(bf)

        static void Main(string[] args)
        {
            PhoneManager phonemanager = PhoneManager.createManagerInstance();
            BinaryFormatter serializer = new BinaryFormatter();
            Stream ws = new FileStream(@"C:\Temp\test.txt", FileMode.OpenOrCreate);
            string pathName = @"C:\Temp\PhoneBook.txt";
            if (File.Exists(pathName)==false)
            {
                ws = new FileStream(@"C:\Temp\PhoneBook.txt", FileMode.OpenOrCreate);
            }
            else
            {
                ws = new FileStream(@"C:\Temp\PhoneBook.txt", FileMode.Open );
                BinaryFormatter deserializer = new BinaryFormatter();
                infoStorage = (HashSet<PhoneInfo>)deserializer.Deserialize(ws);
            }

            int choice;
            while (true)
            {
                while (true)
                {
                    phonemanager.showMenu();
                    if (int.TryParse(Console.ReadLine(), out choice))
                        break;
                }
                try
                {
                    if (choice < 1 || choice > 6)
                    {
                        throw new MenuChoiceException(choice);
                    }
                    switch (choice)
                    {
                        case 1:
                            {

                                phonemanager.inputData(infoStorage);
                                break;
                            }
                        case 2:
                            {
                                phonemanager.listData(infoStorage);
                                break;
                            }
                        case 3:
                            {
                                phonemanager.searchData(infoStorage);
                                break;
                            }
                        case 4:
                            {
                                phonemanager.sortData(infoStorage);
                                break;
                            }
                        case 5:
                            {

                                phonemanager.deleteData(infoStorage);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("프로그램을 종료합니다.");

                                serializer.Serialize(ws, infoStorage);
                                ws.Close();
                                System.Environment.Exit(0); //프로그램 종료 코드
                                break;
                            }
                    }
                }
                catch (MenuChoiceException err)
                {
                    err.showWrongChoice();
                    Console.WriteLine("다시 입력해 주세요.");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "입력오류");
                    continue;
                }
            }
        }
    }
}
