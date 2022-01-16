using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class Extensions
{
    public static float Remap(this float value, float inMin, float inMax, float outMin, float outMax)
    {
        float t = Mathf.InverseLerp(inMin, inMax, value);
        return Mathf.Lerp(outMin, outMax, t);
    }

    /// <summary>
    /// Returns true if vector val direction is between a and b directions
    /// </summary>
    /// <param name="val"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>bool</returns>
    public static bool DirectionBetween(this Vector2 val, Vector2 a, Vector2 b)
    {
        float abDot = Vector2.Dot(a, b);
        float aValDot = Vector2.Dot(val, a);
        float bValDot = Vector2.Dot(val, b);

        return abDot <= aValDot && abDot <= bValDot;
    }

    public static bool VectorWithinDotValue(this Vector2 val, Vector2 dir, float dot)
    {
        return Vector2.Dot(val, dir) >= dot;
    }

    /// <summary>
    /// Returns true if vector val direction is between a and b directions
    /// </summary>
    /// <param name="val"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>bool</returns>
    public static bool DirectionBetween(this Vector3 val, Vector3 a, Vector3 b)
    {
        float abDot = Vector3.Dot(a, b);
        float aValDot = Vector3.Dot(val, a);
        float bValDot = Vector3.Dot(val, b);

        return abDot <= aValDot && abDot <= bValDot;
    }

    public static float PowerOfTwo(this float val)
    {
        return val * val;
    }

    public static float NormalizeDot(Vector3 a, Vector3 b)
    {
        return (Vector3.Dot(a, b) + 1f) / 2f;
    }

    public static Coroutine DelayAction(this MonoBehaviour mb,System.Action act, float delay)
    {
        return mb.StartCoroutine(DelayCoroutine(act, delay));
    }

    static IEnumerator DelayCoroutine(System.Action act, float delay)
    {
        yield return new WaitForSeconds(delay);
        act?.Invoke();
    }

    public static Coroutine DelayAction(this MonoBehaviour mb, System.Action act, WaitForSeconds delay)
    {
        return mb.StartCoroutine(DelayCoroutine(act, delay));
    }

    static IEnumerator DelayCoroutine(System.Action act, WaitForSeconds delay)
    {
        yield return delay;
        act?.Invoke();
    }

    #region DEBUG.Log Wrapper
    /// <summary>
    /// Debug.Log wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void Log(string format, params object[] obj)
    {
        UnityEngine.Debug.LogFormat(format, obj);
    }

    /// <summary>
    /// Debug.Log wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="context">Gameobject context</param>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void Log(Object context, string format, params object[] obj)
    {
        UnityEngine.Debug.LogFormat(context, format, obj);
    }

    /// <summary>
    /// Debug.LogError wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void LogWarning(string format, params object[] obj)
    {
        UnityEngine.Debug.LogWarningFormat(format, obj);
    }

    /// <summary>
    /// Debug.LogError wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="context">Gameobject context</param>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void LogWarning(Object context, string format, params object[] obj)
    {
        UnityEngine.Debug.LogWarningFormat(context, format, obj);
    }

    /// <summary>
    /// Debug.LogError wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void LogError(string format, params object[] obj)
    {
        UnityEngine.Debug.LogErrorFormat(format, obj);
    }

    /// <summary>
    /// Debug.LogError wrapper with required scripting defined symbols "LOG_ENABLED"
    /// </summary>
    /// <param name="context">Gameobject context</param>
    /// <param name="format">Log message</param>
    /// <param name="obj">obj params</param>
    [Conditional("LOG_ENABLED")]
    public static void LogError(Object context, string format, params object[] obj)
    {
        UnityEngine.Debug.LogErrorFormat(context, format, obj);
    }

    #endregion

}
