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

    [Serializable]
    class PhoneInfo : IComparable
    {
        string name;
        string phoneNumber;
        public PhoneInfo(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber= value; } }

        public int CompareTo(object obj)
        {
            PhoneInfo o = (PhoneInfo)obj;
            return this.name.CompareTo(o.name);
        }

        public override bool Equals(object obj)
        {
            PhoneInfo info = (PhoneInfo)obj;
            return this.name.Equals(info.name) && this.phoneNumber.Equals(info.phoneNumber);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(name) + EqualityComparer<string>.Default.GetHashCode(phoneNumber);
        }

        public virtual void ShowPhoneInfo()
        {
            Console.Write("  이름 : {0} ,\t번호 : {1}", name, phoneNumber);
        }

        public override string ToString()
        {
            return string.Format("  이름 : {0} ,\t번호 : {1}", name, phoneNumber);
        }

    }
    class PhoneManager
    {

        static public PhoneManager createManagerInstance()
        {
            return new PhoneManager();
        }

        public void showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=================================주 소 록=================================");
            Console.WriteLine();
            Console.WriteLine("  1. 추가  |  2. 목록  |  3. 검색  |  4. 정렬  |  5. 삭제  |  6. 종료  ");
            Console.WriteLine();
            Console.WriteLine("==========================================================================");
            Console.Write("선택 : ");
        }

        public void inputData(HashSet<PhoneInfo> infoStorage)
        {
            Console.WriteLine();
            Console.WriteLine("데이터를 추가합니다.");
            Console.WriteLine();
            while (true)
            {

                int select1 = 0;

                Console.WriteLine("------------------------ 구 분 ------------------------");
                Console.WriteLine("\t1. 일반 \t2. 학교 \t3. 회사");
                Console.WriteLine("-------------------------------------------------------");


                try
                {
                    while (true)
                    {

                        Console.Write("입력 : ");
                        if (int.TryParse(Console.ReadLine(), out select1))
                        {
                            if (select1 > 3 || select1 < 1)
                                //Console.WriteLine("다시 입력해 주세요.");
                                throw new Exception("1~3의 숫자를 선택해 주세요");
                            else
                                break;
                        }
                        else
                            throw new MenuChoiceException(select1);
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

                PhoneInfo info = null;


                switch (select1)
                {
                    case 1:
                        info = readFriendInfo();
                        break;
                    case 2:
                        info = readUnivFriendInfo();
                        break;
                    case 3:
                        info = readCompanyFriendInfo();
                        break;
                }
                //streamWriter.WriteLine(info);
                bool isAdded = infoStorage.Add(info);
                if (isAdded == true)
                    Console.WriteLine("데이터 입력이 완료되었습니다");
                else
                    Console.WriteLine("이미 저장된 데이터입니다.");
                break;
            }
        }
        public void listData(HashSet<PhoneInfo> infoStorage)
        {
            
                Console.WriteLine();
                Console.WriteLine("============================================================");
                foreach (var curInfo in infoStorage)
                {
                    curInfo.ShowPhoneInfo();
                Console.WriteLine();
                }
                Console.WriteLine("============================================================");

        }

        public void searchData(HashSet<PhoneInfo> infoStorage)
        {
            string name;
            Console.Write("이름 : ");
            name = Console.ReadLine();
            Console.WriteLine("검색하신 학생의 이름 : {0}", name);
            Console.WriteLine();

            PhoneInfo info = searchName(infoStorage,name);
            if (info == null)
            {
                Console.WriteLine("입력된 학생이 데이터에 없습니다.");
            }
            else
            {
                info.ShowPhoneInfo();
                Console.WriteLine();
                Console.WriteLine("데이터 검색이 완료되었습니다.");
            }


           
        }

        private PhoneInfo searchName(HashSet<PhoneInfo> infoStorage, string name)
        {
            foreach (var curInfo in infoStorage)
            {
                if (name.CompareTo(curInfo.Name) == 0)
                    return curInfo;
            }
            return null;
        }

        public void sortData(HashSet<PhoneInfo> infoStorage)
        {
            Console.WriteLine("데이터 정렬을 시작합니다.");
            Console.WriteLine("1. 이름 asc  2. 이름 desc  3. 전화번호 asc 4. 전화번호 desc");
            Console.Write("선택 : ");
            int choice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    break;
            }
            if (choice < 1 || choice > 4)
            {
                throw new MenuChoiceException(choice);
            }

            List<PhoneInfo> list = new List<PhoneInfo>(infoStorage);

            switch (choice)
            {
                case 1:
                    list.Sort();
                    break;
                case 2:
                    list.Sort();
                    list.Reverse();
                    break;

                case 3:
                    list.Sort(new PhoneComparator());
                    break;
                case 4:
                    list.Sort(new PhoneComparator());
                    list.Reverse();
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("정렬이 완료되었습니다.");
            Console.WriteLine();
            Console.WriteLine("============================================================");
            foreach (var curInfo in list)
            {
                curInfo.ShowPhoneInfo();
                Console.WriteLine();
            }
            Console.WriteLine("============================================================");
        }

        public void deleteData(HashSet<PhoneInfo> infoStorage)
        {
            Console.Write("이름 : ");
            string searchName = Console.ReadLine();
            bool bFlag = false;
            foreach (var curinfo in infoStorage)
            {
                if(searchName.CompareTo(curinfo.Name) == 0)
                {
                    infoStorage.Remove(curinfo);
                    bFlag = true;
                    Console.WriteLine("주소록 삭제가 완료되었습니다. ");
                    break;
                }
            }
            if(!bFlag)
            {
                Console.WriteLine("해당하는 데이터가 존재하지 않습니다.");
            }
        }


        public PhoneInfo readFriendInfo()
        {
            
            while (true)
            {
                Console.Write("이름 : ");
                string name = Console.ReadLine();
                Console.Write("전화번호 : ");
                string number = Console.ReadLine();

                if (name == "" || number == "")
                {
                    Console.WriteLine("비어있는 칸이 있습니다. 다시 입력해주세요.");
                    continue;
                }
                else
                    return new PhoneInfo(name, number);
            }
        }
        public PhoneInfo readUnivFriendInfo()
        {
            while (true)
            {
                Console.Write("이름 : ");
                string name = Console.ReadLine();
                Console.Write("전화번호 : ");
                string number = Console.ReadLine();
                Console.Write("전공 : ");
                string major = Console.ReadLine();
                Console.Write("학년 : ");
                int year;
                bool isInt = int.TryParse(Console.ReadLine(), out year);


                if (name == "" || number == "" || major == "" || isInt == false)
                {
                    Console.WriteLine("비어있는 칸이 있습니다. 다시 입력해주세요.");
                    continue;
                }
                else
                    return new PhoneUnivInfo(name, number, major, year);
            }
        }
        public PhoneInfo readCompanyFriendInfo()
        {
            while (true)
            {
                Console.Write("이름 : ");
                string name = Console.ReadLine();
                Console.Write("전화번호 : ");
                string number = Console.ReadLine();
                Console.Write("부서 : ");
                string department = Console.ReadLine();
                Console.Write("직급 : ");
                string rank = Console.ReadLine();

                if (name == "" || number == "" || department == "" || rank == "")
                {
                    Console.WriteLine("비어있는 칸이 있습니다. 다시 입력해주세요.");
                    continue;
                }
                return new PhoneCompanyInfo(name, number, department, rank);
            }
        }

        public void DefaltData(HashSet<PhoneInfo> infoStorage)
        {
            PhoneInfo info = new PhoneInfo(" "," ");
            infoStorage.Add(info);
        }
    }

    class PhoneUnivInfo : PhoneInfo
    {
        string major;
        int year;
        public PhoneUnivInfo(string name, string num, string major, int year) : base(name, num)
        {
            this.major = major;
            this.year = year;
        }


        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\t전공 : {0} ,", major);
            Console.Write("\t학년 : {0}  ", year);
        }
    }
    class PhoneCompanyInfo : PhoneInfo
    {
        string department;
        string rank;
        public PhoneCompanyInfo(string name, string num, string department, string rank) : base(name, num)
        {
            this.department = department;
            this.rank = rank;
        }


        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\t부서 : {0} ,", department);
            Console.Write("\t직급 : {0} ", rank);
        }
    }
}
