using System.Runtime.CompilerServices;

namespace Godot;

public static class FloatExtensions
{
    /// <summary>
    /// To make float interpolation consistent with other 'lerp'able types.
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lerp(this float f, float to, float w) {
        return f + (w * (to - f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroApprox(this float f) {
        return Math.Abs(f) < 1E-06f;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroApprox(this double f) {
        return Math.Abs(f) < 1E-06f;
    }
}

public static class Vector2Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Offset(this Vector2 v, float x, float y) {
        return new(v.X + x, v.Y + y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Rotated90(this Vector2 v) {
        return v.Rotated(0.25f * Mathf.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Rotated180(this Vector2 v) {
        return v.Rotated(0.5f * Mathf.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 RotatedNeg90(this Vector2 v) {
        return v.Rotated(-0.25f * Mathf.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 RotatedNeg180(this Vector2 v) {
        return v.Rotated(-0.5f * Mathf.Tau);
    }
}

public static class Vector3Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 Offset(this Vector3 v, float x, float y, float z) {
        return new(v.X + x, v.Y + y, v.Z + z);
    }

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
    public static Vector3 XZFlattened(this Vector3 v)
    {
        return new(v.X, 0.0f, v.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 XZFlattenedN(this Vector3 v)
    {
        return new Vector3(v.X, 0.0f, v.Z).Normalized();
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

#region Nodes

public static class NodeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RemoveFromParent(this Node node)
    {
        Node parent = node.GetParentOrNull<Node>();

        if (parent is null)
            return;

        parent.RemoveChild(node);
    }
}

public static class Node2DExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SpawnPackage<T>(
        this Node2D node,
        PackedScene scene,
        Vector2 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
        where T: Node2D
    {
        if (!GodotObject.IsInstanceValid(scene))
            return null;

        T instance = scene.Instantiate<T>(editState);
        node.AddChild(instance);

        instance.GlobalPosition = position;
        return instance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SpawnPackage(
        this Node2D node,
        PackedScene scene,
        Vector2 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
    {
        if (!GodotObject.IsInstanceValid(scene))
            return;

        Node2D instance = scene.Instantiate<Node2D>(editState);
        node.AddChild(instance);

        instance.GlobalPosition = position;
    }
}

public static class Node3DExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SpawnPackage<T>(
        this Node3D node,
        PackedScene scene,
        Vector3 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
        where T: Node3D
    {
        if (!GodotObject.IsInstanceValid(scene))
            return null;

        T instance = scene.Instantiate<T>(editState);
        node.AddChild(instance);

        instance.GlobalPosition = position;
        return instance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SpawnPackage(
        this Node3D node,
        PackedScene scene,
        Vector3 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
    {
        if (!GodotObject.IsInstanceValid(scene))
            return;

        Node3D instance = scene.Instantiate<Node3D>(editState);
        node.AddChild(instance);

        instance.GlobalPosition = position;
    }
}

#endregion

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

public static class PackedSceneExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Spawn<T>(
        this PackedScene scene,
        Node parent,
        Vector3 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
        where T: Node3D
    {
        T instance = scene.Instantiate<T>(editState);
        parent.AddChild(instance);

        instance.GlobalPosition = position;
        return instance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Spawn2D(
        this PackedScene scene,
        Node parent,
        Vector2 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
    {
        Node2D instance = scene.Instantiate<Node2D>(editState);
        parent.AddChild(instance);

        instance.GlobalPosition = position;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Spawn3D(
        this PackedScene scene,
        Node parent,
        Vector3 position,
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled)
    {
        Node3D instance = scene.Instantiate<Node3D>(editState);
        parent.AddChild(instance);

        instance.GlobalPosition = position;
    }
}

#endregion