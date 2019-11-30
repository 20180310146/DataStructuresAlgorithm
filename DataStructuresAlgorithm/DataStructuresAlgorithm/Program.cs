using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
           //题目：100块钱买100只鸡，其中小鸡一元三只，母鸡三元一只，公鸡五元一只
           //解题：我给出固定条件，由计算机依次代入数值计算
           for (int a=0;a<=100;a++)
            {
                for (int b=0;b<=100;b++)
                {
                    for (int c=0;c<=100;c++)
                    {
                        int x = 5 * a + 3 * b + c / 3;
                        int y = a + b + c;
                        if (x == 100 && y == 100 && c %3== 0)//条件为 总价100，数量100，小鸡数必须为三的整数倍
                        {
                            Console.WriteLine("公鸡数：{0}\t母鸡数：{1}\t小鸡数：{2}", a, b, c);
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
