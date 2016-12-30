using System.Collections;
using UnityEngine;

/// <summary>
///
/// name:RandomVector3
/// author:Administrator
/// date:2016/12/28 16:33:17
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Assets.Batching.Editor
{
    [SerializeField]
    public struct RandomVector3
    {
        public Vector3 x;

        public Vector3 y;

        public Vector3 z;

        public Vector3 value { get { return RandomNumber(); } }

        public RandomVector3(Vector3 x)
        {
            this.x = x;
            this.y = Vector3.zero;
            this.z = Vector3.zero;
        }

        public RandomVector3(Vector3 x, Vector3 y)
        {
            this.x = x;
            this.y = y;
            this.z = Vector3.zero;
        }

        public RandomVector3(Vector3 x, Vector3 y, Vector3 z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private Vector3 RandomNumber()
        {
            Vector3 result;

            result.x = RandomNumber(x);

            result.y = RandomNumber(y);

            result.z = RandomNumber(z);

            return result;
        }

        private float RandomNumber(Vector3 value)
        {
            float result = Random.Range(value.x, value.y);

            return result;
        }
    }
}
