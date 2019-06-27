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

    /// <summary>
    /// Converts a Vector3 to a Vector 2. Removed the z component completly.
    /// </summary>
    /// <param name="v">The Vector3 to convert.</param>
    /// <returns>A vector2 with the same x and y value of the Vector 3.</returns>
    public static Vector2 ToVector2(this Vector3 v) => new Vector2(v.x, v.y);

}
