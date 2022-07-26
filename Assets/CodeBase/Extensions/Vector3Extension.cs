using UnityEngine;

namespace CodeBase.Extensions
{
    public static class Vector3Extension
    {
        public static float SqrDistance(this Vector3 from, Vector3 to)
        {
            return (to - from).sqrMagnitude;
        }

        public static bool SqrCompareDistance(this Vector3 from, Vector3 to, float borderAmount)
        {
            return SqrDistance(from, to) < borderAmount;
        }
    }
}
