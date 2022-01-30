using UnityEngine;
namespace MUtils
{
    public static class RandomUtils
    {
        public static int Around(float position, float radius)
        {
            return (int)(position + Random.Range( -radius, radius ));
        }
    }
}
