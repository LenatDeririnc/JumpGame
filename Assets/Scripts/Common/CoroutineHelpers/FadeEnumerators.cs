using System;
using System.Collections;
using UnityEngine;

namespace Common.CoroutineHelpers
{
    public static class FadeEnumerators
    {
        public static IEnumerator FadeOut(ICoroutineRunner runner, float inValue, float fadeSpeed, Action callbackAction = null)
        {
            if (inValue < 1)
            {
                inValue -= fadeSpeed;
                yield return new WaitForSeconds(fadeSpeed);
                runner.StartCoroutine(FadeOut(runner, inValue, fadeSpeed, callbackAction));
            }
            else
            {
                callbackAction?.Invoke();
            }
        }

        public static IEnumerator FadeIn(ICoroutineRunner runner, float inValue, float fadeSpeed, Action callbackAction = null)
        {
            if (inValue > 0)
            {
                inValue -= fadeSpeed;
                yield return new WaitForSeconds(fadeSpeed);
                runner.StartCoroutine(FadeOut(runner, inValue, fadeSpeed, callbackAction));
            }
            else
            {
                callbackAction?.Invoke();
            }
        }
    }
}