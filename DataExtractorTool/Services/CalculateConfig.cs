namespace DataExtractorTool.Services
{
    public class CalculateConfig
    {
        public string MaximumValue { get; set; }

        public string MediumValue { get; set; }

        public string MinimumValue { get; set; }

        public RandomNumberType RandomNumberType { get; set; }

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