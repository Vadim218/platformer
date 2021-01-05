using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static float Percent(this Mathf math, float x, float percent){
        return x * (percent / 100);
    }

    public static void Reset(this Transform trans){
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }
}