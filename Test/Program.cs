using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void TestDiv()
        {
            float x = (float)(115 % 9);

            //Point geo = new Point(new UIntPtr(), 0, 0, 0);

            int[] ten = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 10; i++)
            {
                int p0 = ten[i++];
                int p1 = ten[i];
                Console.WriteLine(p0.ToString() + p1.ToString());
            }
        }

        static void TestProper()
        {
            TestProper testProper = new TestProper();

            string ms = Console.ReadLine();

            testProper.Name = ms;
            Console.WriteLine(testProper.Name + "ss");
            Console.ReadKey();
        }

        



    }
    class TestProper
    {

        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    name = "zhangsan";
                }
            }
        }

    }
    class Student
    {

        private string code = "N.A";
        private string name = "not known";
        private int age = 0;

        // 声明类型为 string 的 Code 属性
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        // 声明类型为 string 的 Name 属性
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // 声明类型为 int 的 Age 属性
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public override string ToString()
        {
            return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
        }
    }
}
