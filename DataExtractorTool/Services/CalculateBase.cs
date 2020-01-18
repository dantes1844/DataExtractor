using System.Threading.Tasks;

namespace DataExtractorTool.Services
{
    public abstract class CalculateBase
    {
        public abstract ParallelLoopResult ParallelRun(CalculateConfig config, InputData inputData);

        protected const double FloatDeviation = 0.00001d;
    }
}