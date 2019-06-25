using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Converts a Vector2 to a Vector3, keeping the x and y values of the Vector2 defaulting the z value to 0.
    /// </summary>
    /// <param name="v">The vector2 to convert to a vector3</param>
    /// <returns>A new Vector3 with the x & y value of the Vector2 and 0 for z.</returns>
    public static Vector3 ToVector3(this Vector2 v) => new Vector3(v.x, v.y, 0);
    public static Vector3 ToVector3(this Vector2 v, float z) => new Vector3(v.x, v.y, z);
    
}
