using UnityEngine;
namespace UnknownPanic.Utils
{
    public static class RandomUtils
    {
        public static int Around(int position, int radius)
        {
            return position + Random.Range( -radius, radius );
        }
    }
}
