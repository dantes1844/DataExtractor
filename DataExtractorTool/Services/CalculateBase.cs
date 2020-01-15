using System.Threading.Tasks;

namespace DataExtractorTool.Services
{
    public abstract class CalculateBase
    {
        protected const double IncreaseNumber = 0.00001d;

        protected const int LoopCount = 20000000;

        public abstract ParallelLoopResult ParallelRun(CalculateConfig config, InputData inputData);
    }
}