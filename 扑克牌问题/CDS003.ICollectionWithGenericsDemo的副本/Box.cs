using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 课程范例所需要的模型：盒子（立方体）
    /// </summary>
    public class Box : IEquatable<Box>
    {
        public Box(string f, string c, int r)
        {
            this.Flower = f;
            this.Count = c;
            this.Ranking = r;
        }
        public string  Flower { get; set; }
        public string Count { get; set; }
        public int Ranking { get; set; }

        // 使用 BoxSameDimensions 定义相等性
        public bool Equals(Box other)
        {
            return new BoxSameDimensions().Equals(this, other) ? true : false;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
