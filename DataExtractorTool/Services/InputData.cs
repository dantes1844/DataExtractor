namespace DataExtractorTool.Services
{
    public class InputData
    {
        public int PointNumber { get; set; }

        #region 常量 从入口数据获取

        public double S1 { get; set; }
        public double S2 { get; set; }
        public double S3 { get; set; }
        public double Dr { get; set; }

        #endregion

        public double Ph1 { get; set; }
        public double Ph2 { get; set; }
        public double Pv { get; set; }

        public DataType DataType { get; set; }

        public int RandomNumberStart
        {
            get
            {
                switch (DataType)
                {
                    case DataType.Yilei:
                        return 150;
                    case DataType.Erlei:
                        return 170;
                    case DataType.Sanlei:
                        return 190;
                    default:
                        return 150;
                }
            }
        }

        public int RandomNumberEnd
        {
            get
            {
                switch (DataType)
                {
                    case DataType.Yilei:
                        return 170;
                    case DataType.Erlei:
                        return 190;
                    case DataType.Sanlei:
                        return 210;
                    default:
                        return 170;
                }
            }
        }

        /// <summary>
        /// 随机数 150~170
        /// </summary>
        public double RandP { get; set; }

        public double X { get; set; }

        public double T { get; set; }

        public override string ToString()
        {
            return $"S1={S1},S2={S2},S3={S3},Dr*S3-S1={Dr * S3 - S1},Rp={RandP}";
        }
    }

    public enum DataType
    {
        Yilei = 1,
        Erlei = 22,
        Sanlei = 33
    }
}
