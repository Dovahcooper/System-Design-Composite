using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathHelp
{
    public class MathHelpers
    {
        public static Vector2 Clamp(Vector2 vec, float clampVal)
        {
            if(vec.magnitude > clampVal)
            {
                vec /= vec.magnitude;
                vec *= clampVal;
            }

            return vec;
        }

        public static Vector3 Clamp(Vector3 vec, float clampVal)
        {
            if (vec.magnitude > clampVal)
            {
                vec /= vec.magnitude;
                vec *= clampVal;
            }

            return vec;
        }

        public static Vector4 Clamp(Vector4 vec, float clampVal)
        {
            if (vec.magnitude > clampVal)
            {
                vec /= vec.magnitude;
                vec *= clampVal;
            }

            return vec;
        }
    }
}
