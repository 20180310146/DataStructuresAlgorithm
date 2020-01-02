using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 通过实现 ICollection<T> 接口来创建一个定制类盒子（Box）对象的集合以及一些处理方法；
    /// 相等性：长宽高都相等的情况下是同一个盒子/体积相等的情况下是一个盒子；
    /// 存在性：在 BoxCollection 类实现 Contains 方法，用于检查某个尺寸的盒子是否在集合中。
    /// </summary>
    class Program
    {
      
        static void Main()
        {
            ///向集合添加54张扑克牌
           
            // 定义一个盒子的集合，并向其中添加一下盒子对象
            var bxList = new BoxCollection();
            bxList.Add(new Box("", "大王", 1));
            bxList.Add(new Box("", "小王", 2));
            //定义一个装有所有点数的字符串
            string countAll = "32AKQJ10987654";
            List<string> Flist = new List<string>();
            Flist.Add("黑桃");
            Flist.Add("红桃");
            Flist.Add("梅花");
            Flist.Add("方块");

          
            int ra = 3;
            for (int i = 0; i <= 13; i++)
            {
                if (i == 6)
                {
                    string co1 = countAll.Substring(i, 2);
                    for (int i1 = 0; i1 <= 3; i1++)
                    {
                        string fl = Flist[i1];
                        bxList.Add(new Box(fl, co1, ra));
                        ra++;
                    }
                    i++;
                }
                else
                {
                    string co = countAll.Substring(i, 1);
                    for (int i1 = 0; i1 <= 3; i1++)
                    {
                        string fl = Flist[i1];
                        bxList.Add(new Box(fl, co, ra));
                        ra++;
                    }
                }

            }

            ///随机显示54张扑克牌
            ///

            //调用方法得到一组属于[0,53]的随机数组（数组元素数54个）
            var nlist1 = RandomNumber(0, 53);

            //循环输出54张牌
            int js7 = 1;
            for (int i = 0; i < nlist1.Count; i++)
            {
                var w = bxList[nlist1 [i ]];
                Console.Write("{0}{1}\t", w.Flower, w.Count);
                js7++;
                if (js7 == 7)
                {
                    Console.WriteLine();
                    js7 = 1;
                }
            }


            ///创建四个集合
            ///
            var gatherList1 = new BoxCollection();
            var gatherList2 = new BoxCollection();
            var gatherList3 = new BoxCollection();
            var gatherList4 = new BoxCollection();

            ///将牌随机加到四个集合中
            ///
            var fourList = RandomNumber(0, 53);
            for (int i=0;i<fourList.Count;i++,i ++,i++,i++)
            {
                if (i<=51)
                {
                   
                    
                        gatherList1.Add(bxList[fourList[i]]);
                        gatherList2.Add(bxList[fourList[i+1]]);
                        gatherList3.Add(bxList[fourList[i+2]]);
                        gatherList4.Add(bxList[fourList[i+3]]);
                    
                   
                }
                else
                {
                    gatherList1.Add(bxList[fourList[i]]);
                    gatherList2.Add(bxList[fourList[i + 1]]);
                }
               // if (i <=12)
               // {
               //     gatherList1.Add(bxList[fourList[i]]);
               // }
               // if (i > 12&&i <=24)
               // {
               //     gatherList2.Add(bxList[fourList[i]]);
               // }
               // if (i > 24&& i <= 36)
               // {
               //     gatherList3.Add(bxList[fourList[i]]);
               // }
               //if (i >36)
               // {
               //     gatherList4.Add(bxList[fourList[i]]);
               // }
            }
            Console.WriteLine();
            Console.Write("按下回车开始发牌");
            Console.WriteLine();
            Console.ReadLine();
            //对四个集合内的元素按大小排序
            var ranklist1 = gatherList1.OrderBy(s => s.Ranking);
            var ranklist2 = gatherList2.OrderBy(s => s.Ranking);
            var ranklist3 = gatherList3.OrderBy(s => s.Ranking);
            var ranklist4 = gatherList4.OrderBy(s => s.Ranking);
            //输出四个集合中的牌
            Console.Write("玩家一：");
            foreach (var w in ranklist1 )
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.Write("玩家二：");
            foreach (var w in ranklist2)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.Write("玩家三：");
            foreach (var w in ranklist3)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.WriteLine();
            Console.Write("玩家四：");
            foreach (var w in ranklist4)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }


          
            Console.ReadKey();


            //for(int i = 0; i <= 12; i++)
            //{
            //    string qq = countAll.Substring(i , 1);

            //    Console.WriteLine(qq);
            //}

            //IEnumerator enumerator = bxList.GetEnumerator();
            //int js = 1;
            //while (enumerator.MoveNext())
            //{
            //    var b = (Box)enumerator.Current;
            //    Console.Write("{0}{1}\t{2}\t\t",
            //    b.Flower, b.Count, b.Ranking.ToString()
            //    ) ;
            //    js++;
            //    if (js == 7)
            //    {
            //        Console.WriteLine();
            //        js = 1;
            //    }

            //}
            //RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
            //byte[] byteCsp = new byte[10];
            //csp.GetBytes(byteCsp);
            //Console.WriteLine(BitConverter.ToString(byteCsp));


            //Random rnd = new Random(); //在外面生成对象
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(rnd.Next(1, 10)); //调用同一个 对象产生随机数。
            //}

            //foreach (var w in nlist1)
            //{
            //    Console.Write("{0}\t", w);
            //}


            ///去除数组重复值
            //string[] strs = new string[] { "a", "b", "c", "a", "e", "c", "", "f", "" };
            //List<string> list = new List<string>(strs);
            //List<string> layerNameList = new List<string>(strs);
            //for (int i = 0; i < layerNameList.Count; i++)
            //{
            //    for (int j = layerNameList.Count - 1; j > i; j--)
            //    {
            //        if (layerNameList[i] == layerNameList[j])
            //        {
            //            layerNameList.RemoveAt(j);
            //        }
            //    }
            //}

            //foreach (var w in layerNameList)
            //{
            //    Console.WriteLine(w);
            //}

            //    foreach (var w in sjList)
            //{
            //    Console.WriteLine(w);
            //}
            //Console.WriteLine(sjList.Count);



            //    bxList.Add(new Box(10, 4, 6));
            //    bxList.Add(new Box(4, 6, 10));
            //    bxList.Add(new Box(6, 10, 4));
            //    bxList.Add(new Box(12, 8, 10));

            //    // 相同维度的盒子不允许加入
            //    bxList.Add(new Box(10, 4, 6));

            //    // 检查移除盒子的方法
            //    Display(bxList);
            //    Console.WriteLine("移除 6x10x4");
            //    bxList.Remove(new Box(6, 10, 4));
            //    Display(bxList);
            //    // 移除的另外一些实现
            //    bxList.Remove(bxList[0]);
            //    bxList.Remove(bxList.FirstOrDefault(x => x.Length == 6));
            //    Display(bxList);

            //    // 检查包含盒子的方法，该方法使用长宽高直接进行比较
            //    var BoxCheck = new Box(8, 12, 10);
            //    Console.WriteLine("按照长宽高三维符合性条件，盒子{0}x{1}x{2}结果： {3}",
            //        BoxCheck.Height.ToString(), BoxCheck.Length.ToString(),
            //        BoxCheck.Width.ToString(), bxList.Contains(BoxCheck).ToString());

            //    // 检查重载的 Contains 方法，该方法使用体积来做比较
            //    Console.WriteLine("按照体积符合性条件，盒子{0}x{1}x{2}结果： {3}",
            //        BoxCheck.Height.ToString(), BoxCheck.Length.ToString(),
            //        BoxCheck.Width.ToString(), bxList.Contains(BoxCheck,
            //        new BoxSameVolume()).ToString());


            //}

            //public static void Display(BoxCollection bxList)
            //{
            //    Console.WriteLine("\n高\t长\t宽\t哈希码");
            //    foreach (Box bx in bxList)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            //            bx.Height.ToString(), bx.Length.ToString(),
            //            bx.Width.ToString(), bx.GetHashCode().ToString());
            //    }

            //    // 直接使用枚举子便利处理的结果
            //    //IEnumerator enumerator = bxList.GetEnumerator();
            //    //Console.WriteLine("\n高\t长\t宽\t哈希码");
            //    //while (enumerator.MoveNext())
            //    //{
            //    //    var b = (Box)enumerator.Current;
            //    //    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            //    //    b.Height.ToString(), b.Length.ToString(),
            //    //    b.Width.ToString(), b.GetHashCode().ToString());
            //    //}

            //    Console.WriteLine();
            //}

        }



        /// <summary>
        /// 创建一个得到随机数数组的方法(方法参数代表随机数范围）
        /// </summary>
        /// <returns></returns>
        private static List<Int32> RandomNumber(int begin,int end)
        {
            List<Int32> sjList = new List<Int32>();
            for (int i = 0; i < 1000; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                //Console.WriteLine(random.Next(1,54));
                sjList.Add(random.Next(begin, end+1));
            }

            List<Int32> nlist = sjList;
            for (int i = 0; i < sjList.Count; i++)
            {

                for (int j = sjList.Count - 1; j > i; j--)
                {
                    if (sjList[i] == nlist[j])
                    {
                        sjList.RemoveAt(j);
                    }
                }

            }
            return sjList;
        }

     
        
    }
}
