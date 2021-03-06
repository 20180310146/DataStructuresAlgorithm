﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

        /// <summary>
        /// 盒子，用于后续描述对象相等性处理的例子
        /// </summary>
        public class Box
        {
            public int Height { get; set; }
            public int Length { get; set; }
            public int Width { get; set; }

            public Box(int h, int l, int w)
            {
                this.Height = h;
                this.Length = l;
                this.Width = w;
            }

            public override String ToString()
            {
                return $@"({Height}, {Length}, {Width})";
            }
        }
    }

