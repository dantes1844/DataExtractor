using System.Threading.Tasks;

namespace DataExtractorTool.Services
{
    public abstract class CalculateBase
    {
        protected const double IncreaseNumber = 0.00001d;

        public abstract ParallelLoopResult ParallelRun(CalculateConfig config, InputData inputData);
    }
}