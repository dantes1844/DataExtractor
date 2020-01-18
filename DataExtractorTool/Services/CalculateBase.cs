using System.Threading.Tasks;
using DataExtractorTool.Models;

namespace DataExtractorTool.Services
{
    public abstract class CalculateBase
    {
        public abstract ParallelLoopResult ParallelRun(CalculateConfig config, InputData inputData);

        protected const double FloatDeviation = 0.00001d;
    }
}