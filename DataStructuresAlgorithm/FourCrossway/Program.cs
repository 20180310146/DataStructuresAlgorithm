using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FourCrossway
{
    class Prom
    {

        //class Program
        //{
        //    int TimesCalled = 0;
        //    void Display(object state)
        //    {
        //        Console.WriteLine("{0} {1} keep running.", (string)state, ++TimesCalled);
        //    }
        //    static void Main(string[] args)
        //    {
        //        Program p = new Program();
        //        //2秒后第一次调用，每1秒调用一次
        //        System.Threading.Timer myTimer = new System.Threading.Timer(p.Display, "Processing timer event", 2000, 1000);
        //        // 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

        //        Console.WriteLine("Timer started.");
        //        Console.ReadLine();
        //    }
        //}





        static Stack<string> light;
        static Stack<string> nulllight;
        static int  conu = 1;
        static string deng;
        static System.Timers.Timer  t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于红绿灯的变换
        static System.Timers.Timer t1 = new System.Timers.Timer(30000);//实例化Timer类，设置间隔时间为10000毫秒；用于红绿灯的变换
        /// <summary>
        /// 控制台显示十字路口
        /// </summary>
        /// <param name="args"></param>
        public  void Crossroad(object state)
        {
            t.Stop(); //先关闭定时器

            //主干道上部
            for (int i =0;i<12;i ++)
            {
                for (int j=0;j<33;j++)
                {
                   
                    if ((i == 6 && j == 29)|| (i == 10 && j == 29))
                    {
                        if (i == 10 && j == 29)
                        {
                            Console.Write(deng);
                        }
                        else {
                            Console.Write("主");
                        }
                       
                    }
                    else { Console.Write("  "); }
                 
                    if (j == 25||j==32)
                    {
                        Console.Write("|");
                    }
                   
                   
                }
                Console.WriteLine("");
                
            }

            //支干道
            for (int i = 0; i < 5; i++)
            {
                if (i==0||i==4)
                {
                    for (int j = 0; j < 50; j++)
                    {
                     
                        
                        
                            if ((j > 25 && j < 34) || (j < 10)) { Console.Write("  "); }
                            else
                            {
                                Console.Write("—");
                            }
                        


                    }
                }
                if (i == 2)
                {
                    for (int j=0;j<50;j++)
                    {
                        Console.Write("  ");
                        if (j == 15)
                        {
                            Console.Write("支");
                        }
                    }
                }
                 Console.WriteLine(""); 


            }


            //主干道下部
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    
                    Console.Write("  "); 

                    if (j == 25 || j == 32)
                    {
                        Console.Write("|");
                    }

                }
                Console.WriteLine("");

            }
            t.Start(); //执行完毕后再开启器

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="args"></param>
       //public Prom()
       // {
       //     System.Timers.Timer t = new System.Timers.Timer(10000);//实例化Timer类，设置间隔时间为10000毫秒；
       //     t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；
       //     t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
       //     t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
       //     t.Start(); //启动定时器
       //                //上面初始化代码可以写到构造函数中




       //     //System.Timers.Timer t = new System.Timers.Timer();
       //     //t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
       //     //t.Interval = 1000;
       //     //t.Enabled = true;
       // }

        static void Main(string[] args)
        {

            //light = new Stack<string>();
            //light.Push("红");
            ////light.Push("黄");
            //light.Push("绿");
            //nulllight = new Stack<string>();

            deng = "绿";
           t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；
            //t.Elapsed += new System.Timers.ElapsedEventHandler(Crossroad);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            t.Start(); //启动定时器
                       //上面初始化代码可以写到构造函数中


            //t1.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；
            //t1.Elapsed += new System.Timers.ElapsedEventHandler(Crossroad);//到达时间的时候执行事件；
            //t1.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            //t1.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            //t1.Start(); //启动定时器


            Prom p = new Prom();
            //2秒后第一次调用，每1秒调用一次
            System.Threading.Timer myTimer = new System.Threading.Timer(p.Crossroad, "Processing timer event", 2000, 10000);
            // 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            //System.Timers.Timer t1 = new System.Timers.Timer();
            //t1.Elapsed += new ElapsedEventHandler(OnTimedEvent4);
            //t1.Interval = 3000;
            //t1.Enabled = true;

            //Crossroad();
            Console.Read();
        }
      
      
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            t.Stop(); //先关闭定时器
           
         

            //Console.Clear();
            if (conu>=1&&conu<=27)
            {
                deng = "绿";
                //Console.Write("绿");
                conu++;
            }
           else if (conu>27&&conu<=30)
            {
                deng = "黄";
                //Console.Write("黄");
                conu++;
            }
          else  if (conu >30&& conu <60)
            {
                deng = "红";
                //Console.Write("红");
                conu++;
            }
           else if (conu==60)
            {
                deng = "红";
                //Console.Write("红");
                conu = 1;
            }
           
            t.Start(); //执行完毕后再开启器
            //Console.Clear();
            //Console.Write(deng);

            //Console.Clear();
            ////Stack<string> light = new Stack<string>();
            ////light.Push("红");
            ////light.Push("黄");
            ////light.Push("绿");
            ////Stack<string> nulllight = new Stack<string>();
            ////nulllight.Push( light.Pop());
            //if (light=="红")
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //else
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //Console.Write(light);



            //Console.Clear();
            //Console.Write(light);
            //Console.Clear();
            //Console.WriteLine(DateTime.Now);
        }
        //private static void OnTimedEvent1(object source, ElapsedEventArgs e)
        //{
        //    light = "绿";
        //    Console.Write(light);

        //    System.Timers.Timer t = new System.Timers.Timer();
        //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    t.Interval = 27000;
        //    t.Enabled = true;
        //}
        //private static void OnTimedEvent2(object source, ElapsedEventArgs e)
        //{
        //    light = "红";
        //    Console.Write(light);

        //    System.Timers.Timer t = new System.Timers.Timer();
        //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    t.Interval = 27000;
        //    t.Enabled = true;
        //}
        //public static void deng()
        //{
        //    Stack<string> light = new Stack<string>();
        //    light.Push("红");
        //    light.Push("黄");
        //    light.Push("绿");
        //    Stack<string> nulllight = new Stack<string>();
        //}
        private static void OnTimedEvent4(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.Write(deng);
        }

    }
}
