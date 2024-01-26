using System.Runtime.CompilerServices;

namespace Godot;

public static class FloatExtensions
{
    /// <summary>
    /// To make float interpolation consistent with other 'lerp'able types.
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lerp(this float f, float to, float w) {
        return f + (to - f) * w;
    }
}

public static class DoubleExtensions
{
    /// <summary>
    /// To make float interpolation consistent with other 'lerp'able types.
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Lerp(this double f, double to, double w) {
        return f + (w * (to - f));
    }
}

public static class Vector3Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 XZAsVec2(this Vector3 v) {
        return new(v.X, v.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float XZSquareMagnitude(this Vector3 v) {
        return (v.X * v.X) + (v.Z * v.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float XZMagnitude(this Vector3 v) {
        return Mathf.Sqrt((v.X * v.X) + (v.Z * v.Z));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 XZNormalised(this Vector3 v, bool zeroY = true)
    {
        float len = v.XZMagnitude();
        return new(v.X / len, zeroY ? 0.0f : v.Y, v.Z / len);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 XZScale(this Vector3 v, float amount)
    {
        Vector3 scaled = v;

        scaled.X *= amount;
        scaled.Z *= amount;

        return scaled;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 XZLerp(this Vector3 v, Vector3 o, float w)
    {
        Vector3 result = v;
        result.X = result.X.Lerp(o.X, w);
        result.Z = result.Z.Lerp(o.Z, w);

        return result;
    }
}

public static class Trans3DExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Transform3D SetForward(this Transform3D t, float w, Vector3 forward, Vector3? up = null)
    {
        Transform3D nt = t;
        nt.Basis.Z = forward;
        nt.Basis.Y = up ?? Vector3.Up;
        nt.Basis.X = nt.Basis.Y.Cross(forward);
        nt.Basis = nt.Basis.Orthonormalized();

        return t.InterpolateWith(nt, w);
    }
}

# region Godot Collections

public static class GArrayExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty(this Collections.Array a) {
        return a.Count < 1;
    }
}

public static class GDictExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty(this Collections.Dictionary d) {
        return d.Count < 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Get<[MustBeVariant] T>(this Collections.Dictionary d, StringName key) {
        return d[key].As<T>();
    }
}

#endregion