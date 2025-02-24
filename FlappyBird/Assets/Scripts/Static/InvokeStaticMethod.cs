using System;
using System.Collections;
using UnityEngine;

public static class InvokeStaticMethod
{
    public static IEnumerator ReloadWithDelay(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
