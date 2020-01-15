namespace DataExtractorTool.Services
{
    public class CalculateConfig
    {
        public string MaximumValue { get; set; }

        public string MediumValue { get; set; }

        public string MinimumValue { get; set; }

        public RandomNumberType RandomNumberType { get; set; }

        /// <summary>
        /// 执行的次数
        /// </summary>
        public long LoopCount { get; set; }

        public double RandomNumberStart { get; set; }

        public double RandomNumberEnd { get; set; }

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