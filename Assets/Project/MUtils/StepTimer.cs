using System;
namespace MUtils
{
    [Serializable]
    public class StepTimer
    {
        public int step;
        public float interval;
        public float time_multiplier => step / interval;
        public int GetStep(float cur_time)
        {
            return (int)(cur_time * time_multiplier) % step;
        }
    }
}
