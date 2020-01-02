using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = PersonRepository.InitialPersonCollection();
            int y;
            int d;
            int yz = 0;
            int dz = 0;
            int i = 0;
            foreach (var w in list)
            {
                y = DateTime.Now.Year - (w.Birthday.Year + 1);
                d = (12 - w.Birthday.Month) * 30 + (30 - w.Birthday.Day) + ((DateTime.Now.Month - 1) * 30) + DateTime.Now.Day;
                yz = y + yz;
                dz = d + dz;
                i++;

                //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", w.Name, w.Province, w.City, w.Sex, w.Birthday, w.Email);
            }
            if (dz / i > 365)
            { Console.WriteLine("平均年龄{0}周年{1}天", (yz / i) + 1, (dz / i) - 365); }
            else
                Console.WriteLine("平均年龄{0}周年{1}天", yz / i, dz / i);



            ///计算各个姓的个数
            List<string> fxlist = Sz();
            List<Person> nlist = new List<Person>();
            List<Person> nlist1 = new List<Person>();


            for (int x = 0; x < list.Count; x++)
            {
                //如果是一个复姓，放入一个集合
                string qq = list[x].Name.Substring(0, 2);
                if (fxlist.Contains (qq))
                {
                    nlist.Add(list[x]);
                }
                //不是复姓放入另一个集合
                else
                {
                    nlist1.Add(list[x]);
                }
            }
           //输出单姓
            var ww = nlist1.GroupBy(s => s.Name.Substring(0, 1));
            foreach (var w in ww)
            {
                Console.WriteLine("{0}姓：{1}人", w.Key, w.Count());
            }
            //输出复姓
            var ww1 = nlist.GroupBy(s => s.Name.Substring(0, 2));
            foreach (var w in ww1)
            {
                Console.WriteLine("{0}姓：{1}人", w.Key, w.Count());
            }
                Console.Read();



            
        }
       /// <summary>
       /// 创建一个包含所有复姓的集合
       /// </summary>
       /// <returns></returns>
        public static  List <string> Sz()
        {
            int i = 0;
            List<string> stlist = new List<string>();
            string fx ="欧阳太史端木上官司马东方独孤南宫万俟闻人夏侯诸葛尉迟公羊赫连澹台皇甫宗政濮阳公冶太叔申屠公孙慕容仲孙钟离长孙宇文司徒鲜于司空闾丘子车亓官司寇巫马公西颛孙壤驷公良漆雕乐正宰父谷梁拓跋夹谷轩辕令狐段干百里呼延东郭南门羊舌微生公户公玉公仪梁丘公仲公上公门公山公坚左丘公伯西门公祖第五公乘贯丘公皙南荣东里东宫仲长子书子桑即墨达奚褚师";

            for (int yy=0;yy <=80;yy ++ )
            {
                string ww = fx.Substring(i ,2);
                stlist.Add(ww);
                i++;i++;
            }
            return stlist;
            //foreach (var w in stlist )
            //{
            //    Console.WriteLine(w);
            //}
            //Console.Read();
        }
        //欧阳太史端木上官司马东方独孤南宫万俟闻人夏侯诸葛尉迟公羊赫连澹台皇甫宗政濮阳公冶太叔申屠公孙慕容仲孙钟离长孙宇文司徒鲜于司空闾丘子车亓官司寇巫马公西颛孙壤驷公良漆雕乐正宰父谷梁拓跋夹谷轩辕令狐段干百里呼延东郭南门羊舌微生公户公玉公仪梁丘公仲公上公门公山公坚左丘公伯西门公祖第五公乘贯丘公皙南荣东里东宫仲长子书子桑即墨达奚褚师";

    }
}
