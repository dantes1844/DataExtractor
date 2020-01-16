namespace DataExtractorTool.Services
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
    }

    public enum RandomNumberType
    {
        SameRandomNumber,

        RandomNumberPerRecord
    }
}