namespace DataExtractorTool.Models
{
    public class CalculateConfig
    {
        public RandomNumberType RandomNumberType { get; set; }

        /// <summary>
        /// 执行的次数
        /// </summary>
        public long YileiLoopCount { get; set; }

        public long ErleiLoopCount { get; set; }

        public long SanleiLoopCount { get; set; }

        /// <summary>
        /// 一类修正值
        /// </summary>
        public double YileiIncreaseNumber { get; set; }

        /// <summary>
        /// 二类修正值
        /// </summary>
        public double ErleiIncreaseNumber { get; set; }

        /// <summary>
        /// 三类修正值
        /// </summary>
        public double SanleiIncreaseNumber { get; set; }

        /// <summary>
        /// 差值
        /// </summary>
        public double DefaultDeviation { get; set; } = 2;

        /// <summary>
        /// T的最小值
        /// </summary>
        public double? TMinimumValue { get; set; }

        /// <summary>
        /// 一类数据x值的默认初始值
        /// </summary>
        public double? TypeOneDefaultX { get; set; }

        /// <summary>
        /// 二类x值的默认初始值
        /// </summary>
        public double? TypeTwoDefaultX { get; set; }

        /// <summary>
        /// 三类x值的默认初始值
        /// </summary>
        public double? TypeThreeDefaultX { get; set; }
    }

    public enum RandomNumberType
    {
        SameRandomNumber,

        RandomNumberPerRecord
    }
}