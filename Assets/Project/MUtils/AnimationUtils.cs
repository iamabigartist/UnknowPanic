namespace MUtils
{
    public static class AnimationUtils
    {
        /// <returns>alpha 0~1 </returns>
        public static float blink(float remain_time, float interval)
        {
            float result = remain_time / interval;
            result -= (int)result;
            return result;
        }

        public static void press(this ref bool button)
        {
            button = !button;
        }


    }
}
