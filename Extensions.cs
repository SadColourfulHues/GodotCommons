using System.Runtime.CompilerServices;

namespace Godot;

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interned(this string s)
    {
        return s switch {
            null => null,
            _ => string.Intern(s)
        };
    }
}

public static partial class FloatExtensions
{
    /// <summary>
    /// To make float interpolation consistent with other 'lerp'able types.
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lerp(this float f, float to, float w) {
        return f + (w * (to - f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float InverseLerp(this float f, float from, float to) {
        return(f - from) / (to - from);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroApprox(this float f) {
        return MathF.Abs(f) < 1E-06f;
    }

    /// https://github.com/godotengine/godot/blob/4a0160241fd0c1e874e297f6b08676cf0761e5e8/core/math/math_funcs.h#L599
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEqualApprox(this float f, float b, float tolerance = 8.854187817f)
    {
        if (f == b)
			return true;

		return MathF.Abs(f - b) < tolerance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Min(this float f, float other) {
        return MathF.Min(f, other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Max(this float f, float other) {
        return MathF.Max(f, other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamped(this float f, float min, float max) {
        return MathF.Max(min, MathF.Min(max, f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Abs(this float f) {
        return MathF.Abs(f);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Squared(this float f) {
        return f * f;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Cubed(this float f) {
        return f * f * f;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Pow(this float f, float power) {
        return MathF.Pow(f, power);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Sqrt(this float f) {
        return MathF.Sqrt(f);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 AsVector2(this float v) {
        return new(v, v);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 AsVector3(this float v) {
        return new(v, v, v);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color AsColour(this float v, float a = 1.0f) {
        return new(v, v, v, a);
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

public static class GodotObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetMeta<[MustBeVariant] T>(this GodotObject @object, StringName id) {
        return @object.GetMeta(id).As<T>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetMetaOr<[MustBeVariant] T>(this GodotObject @object, StringName id, T defaultValue = default)
    {
        if (!@object.HasMeta(id))
            return defaultValue;

        return @object.GetMeta(id).As<T>();
    }
}

public static class Vector2Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ReplaceX(this Vector2 v, float x)
        => new(x, v.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ReplaceY(this Vector2 v, float y)
        => new(v.X, y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Offset(this Vector2 v, float x, float y) {
        return new(v.X + x, v.Y + y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Rotated90(this Vector2 v) {
        return v.Rotated(0.25f * MathF.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Rotated180(this Vector2 v) {
        return v.Rotated(0.5f * MathF.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 RotatedNeg90(this Vector2 v) {
        return v.Rotated(-0.25f * MathF.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 RotatedNeg180(this Vector2 v) {
        return v.Rotated(-0.5f * MathF.Tau);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Scaled(this Vector2 v, float s) {
        return new(v.X * s, v.Y * s);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Scaled(this Vector2 v, float x, float y) {
        return new(v.X * x, v.Y * y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ScaledX(this Vector2 v, float x) {
        return new(v.X * x, v.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ScaledY(this Vector2 v, float y) {
        return new(v.X, v.Y * y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsXDominant(this Vector2 v) {
        Vector2 absV = v.Abs();
        return (absV.X > absV.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 XFlattened(this Vector2 v) {
        return new(0.0f, v.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 YFlattened(this Vector2 v) {
        return new(v.X, 0.0f);
    }
}

public static class Vector3Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 ReplaceX(this Vector3 v, float x)
        => new(x, v.Y, v.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 ReplaceY(this Vector3 v, float y)
        => new(v.X, y, v.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 ReplaceZ(this Vector3 v, float z)
        => new(v.X, v.Y, z);

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
        return MathF.Sqrt((v.X * v.X) + (v.Z * v.Z));
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

public static class ColourExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color Clamped(this Color colour)
    {
        return new(
            colour.R.Clamped(0.0f, 1.0f),
            colour.G.Clamped(0.0f, 1.0f),
            colour.B.Clamped(0.0f, 1.0f),
            colour.A.Clamped(0.0f, 1.0f)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ShiftH(this Color colour, float hue) {
        return Color.FromHsv(colour.H + hue, colour.S, colour.V);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ShiftS(this Color colour, float saturation) {
        return Color.FromHsv(colour.H, colour.S + saturation, colour.V);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ShiftV(this Color colour, float value) {
        return Color.FromHsv(colour.H, colour.S, colour.V + value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ShiftSV(this Color colour, float saturation, float value) {
        return Color.FromHsv(colour.H, colour.S + saturation, colour.V + value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ShiftHSV(this Color colour, float hue, float saturation, float value) {
        return Color.FromHsv(colour.H + hue, colour.S + saturation, colour.V + value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceR(this Color colour, float r) {
        return new(r, colour.G, colour.B, colour.A);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceG(this Color colour, float g) {
        return new(colour.R, g, colour.B, colour.A);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceB(this Color colour, float b) {
        return new(colour.R, colour.G, b, colour.A);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceA(this Color colour, float a) {
        return new(colour.R, colour.G, colour.B, a);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceH(this Color colour, float h) {
        return Color.FromHsv(h, colour.S, colour.V);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceS(this Color colour, float s) {
        return Color.FromHsv(colour.H, s, colour.V);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ReplaceV(this Color colour, float v) {
        return Color.FromHsv(colour.H, colour.S, v);
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

    /// <summary>
    /// A shorthand for getting nodes with the exact same name as their type.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetNodeComponent<T>(this Node node) where T: Node {
        return node.GetNode<T>(typeof(T).Name);
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

public static class Rigidbody3DExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyTorqueAndImpulse(
        this RigidBody3D rb,
        Vector3 force,
        Vector3 torque)
    {
        rb.ApplyImpulse(force);
        rb.ApplyTorque(torque);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyVisualTorqueAndImpulse(
        this RigidBody3D rb,
        Vector3 force,
        Vector3 torque)
    {
        rb.ApplyImpulse(force);
        rb.ApplyTorqueImpulse(torque);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyTorqueAndImpulse(
        this RigidBody3D rb,
        Vector3 force,
        Vector3 torque,
        Vector3 fromPosition)
    {
        rb.ApplyImpulse(force, fromPosition);
        rb.ApplyTorque(torque);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyVisualTorqueAndImpulse(
        this RigidBody3D rb,
        Vector3 force,
        Vector3 torque,
        Vector3 fromPosition)
    {
        rb.ApplyImpulse(force, fromPosition);
        rb.ApplyTorqueImpulse(torque);
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