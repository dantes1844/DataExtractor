using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataExtractor
{
    public class InputData
    {
        public int PointNumber { get; set; }

        #region 常量 从入口数据获取

        public double S1 { get; set; }
        public double S2 { get; set; }
        public double S3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Dr { get; set; }

        #endregion

        public double Ph1 { get; set; }
        public double Ph2 { get; set; }
        public double Pv { get; set; }

        //public bool IsValidX()
        //{
        //    var flag1 = Ph1 > Ph2 && Ph2 > Pv;
        //    var flag2 = Math.Abs(Ph1 / Pv - Dr) <= 0.0001;
        //    if (flag2 && flag1)
        //    {
        //        Debug.WriteLine($"Ph1={Ph1},Ph2={Ph2},Pv={Pv},Math.Abs(Ph1 / Pv - Dr)={Math.Abs(Ph1 / Pv - Dr)}");
        //    }
        //    return flag2 && flag1;
        //}

        /// <summary>
        /// 随机数 150~170
        /// </summary>
        public double RandP
        {
            get
            {
                var random = new Random();
                return (170 - 150) * random.NextDouble() + 150;
            }
        }

        public double X { get; set; }

        public double T { get; set; }

        /// <summary>
        /// 遍历次数
        /// </summary>
        public int Count { get; set; }

        public override string ToString()
        {
            return $"Count={Count},S1={S1},S2={S2},S3={S3},Dr*S3-S1={Dr * S3 - S1},Rp={RandP}";
        }
    }
}
