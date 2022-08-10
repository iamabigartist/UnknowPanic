using UnityEngine;
namespace MUtils
{
    public static class RandomUtil
    {
        public static int Around(float position, float radius)
        {
            return (int)(position + Random.Range( -radius, radius ));
        }
    }
}
