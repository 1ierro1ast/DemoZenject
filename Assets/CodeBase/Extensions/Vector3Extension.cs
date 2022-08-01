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

        public static void ConvertToVector2ZAsY(this Vector3 vector3, out Vector2 to)
        {
            to = new Vector2(vector3.x, vector3.z);
        }

        public static Vector2 ConvertToVector2ZAsY(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }
    }

    public static class Vector2Extension
    {
        public static float SqrDistance(this Vector2 from, Vector2 to)
        {
            return (to - from).sqrMagnitude;
        }

        public static bool SqrCompareDistance(this Vector2 from, Vector2 to, float borderAmount)
        {
            return SqrDistance(from, to) < borderAmount;
        }

        public static void ConvertToVector3YAsZ(this Vector2 vector2, out Vector3 to)
        {
            to = new Vector3(vector2.x, 0, vector2.y);
        }

        public static Vector3 ConvertToVector3YAsZ(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }

        public static void ConvertToVector3YAsZ(this Vector2 vector2, out Vector3 to, float y)
        {
            to = new Vector3(vector2.x, y, vector2.y);
        }

        public static Vector3 ConvertToVector3YAsZ(this Vector2 vector2, float y)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }
    }

    public static class GameObjectExtension
    {
        public static Component GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent(out T tcomponent))
            {
                return tcomponent;
            }

            return gameObject.AddComponent<T>();
        }
    }
}
