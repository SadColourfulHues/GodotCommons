using System.Runtime.CompilerServices;

namespace SCHGodot.Easing;

/// Thanks to https://easings.net ///
public static partial class FloatExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseSinIn(this float x)
        => 1f - MathF.Cos((x * MathF.PI) * 0.5f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseSinOut(this float x)
        => MathF.Sin((x * MathF.PI) * 0.5f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseSinInOut(this float x)
        => -(MathF.Cos(MathF.PI * x) - 1f) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuadraticIn(this float x)
        => x * x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuadraticOut(this float x)
        => 1f - MathF.Pow(1f - x, 2f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuadraticInOut(this float x)
        => x < 0.5f
            ? 2f * x * x
            : 1f - MathF.Pow(-2f * x + 2f, 2f) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCubicIn(this float x)
        => x * x * x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCubicOut(this float x)
        => 1f - MathF.Pow(1f - x, 3f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCubicInOut(this float x)
        => x < 0.5f
            ? 4f * x * x * x
            : 1f - MathF.Pow(-2f * x + 2f, 3f) / 2f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuarticIn(this float x)
        => x * x * x * x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuarticOut(this float x)
        => 1f - MathF.Pow(1f - x, 4f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuarticInOut(this float x)
        => x < 0.5f
            ? 8f * x * x * x * x
            : 1f - MathF.Pow(-2f * x + 2f, 4f) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuinticIn(this float x)
        => x * x * x * x * x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuinticOut(this float x)
        => 1f - MathF.Pow(1f - x, 5f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseQuinticInOut(this float x)
        => x < 0.5f
            ? 16f * x * x * x * x * x
            : 1f - MathF.Pow(-2f * x + 2f, 5f) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseExponentialIn(this float x)
        => x.IsZeroApprox() ? 0f : MathF.Pow(2f, 10f * x - 10f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseExponentialOut(this float x)
        => x.IsEqualApprox(1f) ? 1f : 1f - MathF.Pow(2f, -10f * x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseExponentialInOut(this float x)
        => x.IsZeroApprox()
            ? 0f
            : x.IsEqualApprox(1f)
            ? 1f
            : x < 0.5f ? MathF.Pow(2f, 20f * x - 10f) * 0.5f
            : (2f - MathF.Pow(2f, -20f * x + 10f)) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCircularIn(this float x)
        => 1f - MathF.Sqrt(1f - (x * x));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCircularOut(this float x)
        => MathF.Sqrt(1f - MathF.Pow(x - 1f, 2f));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseCircularInOut(this float x)
        => x < 0.5f
            ? (1f - MathF.Sqrt(1f - MathF.Pow(2f * x, 2f))) * 0.5f
            : (MathF.Sqrt(1f - MathF.Pow(-2f * x + 2f, 2f)) + 1f) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseBackIn(this float x)
        => (1.70158f + 1f) * x * x * x - 1.70158f * x * x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseBackOut(this float x)
        => 1 + 2.70158f * MathF.Pow(x - 1f, 3f) + (1.70158f) * MathF.Pow(x - 1f, 2f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float EaseBackInOut(this float x)
        => x < 0.5f
            ? (MathF.Pow(2f * x, 2f) * (3.594909f * 2f * x - 2.594909f)) * 0.5f
            : (MathF.Pow(2f * x - 2f, 2f) * (3.594909f * (x * 2f - 2f) + 2.594909f) + 2f) * 0.5f;

    public static float EaseElasticIn(this float x)
        => x.IsZeroApprox()
            ? 0f
            : x.IsEqualApprox(1f)
            ? 1f
            : -MathF.Pow(2f, 10f * x - 10f) * MathF.Sin((x * 10f - 10.75f) * ((2f * MathF.PI) / 3f));

    public static float EaseElasticOut(this float x)
        => x.IsZeroApprox()
            ? 0f
            : x.IsEqualApprox(1f)
            ? 1f
            : MathF.Pow(2f, -10f * x) * MathF.Sin((x * 10f - 0.75f) * ((2f * MathF.PI) / 3f)) + 1f;

    public static float EaseElasticInOut(this float x)
        => x.IsZeroApprox()
            ? 0f
            : x.IsEqualApprox(1f)
            ? 1f
            : x < 0.5f
            ? -(MathF.Pow(2f, 20f * x - 10f) * MathF.Sin((20f * x - 11.125f) * 1.396263402f)) / 2f
            : (MathF.Pow(2f, -20f * x + 10f) * MathF.Sin((20f * x - 11.125f) * 1.396263402f)) / 2f + 1f;
}