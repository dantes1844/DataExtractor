namespace DataExtractorTool.Services
{
    public class CalculateConfig
    {
        public RandomNumberType RandomNumberType { get; set; }

        /// <summary>
        /// 执行的次数
        /// </summary>
        public long LoopCount { get; set; }

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