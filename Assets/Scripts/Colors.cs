using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Colors
{
    public static Color32 DarkenColor(Color32 c, float v)
    {
        Colors.Log(c);
        //Vector3 colorV2 = new Vector3(c.r, c.b, c.g);
        //UnityEngine.Debug.Log(colorV2.ToString());
        float _r = c.r;
        _r -= v;
        if (_r <= 0)
        {
            _r = 0;
        }
        float _b = c.g;
        _b -= v;
        if (_b <= 0)
        {
            _b = 0;
        }
        float _g = c.g;
        _g -= v;
        if (_g <= 0)
        {
            _g = 0;
        }
        Vector3 colorV = new Vector3(_r, _b, _g);
        UnityEngine.Debug.Log(colorV.ToString());
        return new Color32((byte)_r, (byte)_g, (byte)_b, 255);
    }

    private static void Log(Color32 c)
    {
        Vector3 colorV2 = new Vector3(c.r, c.b, c.g);
        UnityEngine.Debug.Log(colorV2.ToString());
    }

    internal static Color32 BrightenColor(Color32 c, float v)
    {
        float _r = c.r;
        _r += v;
        if (_r >= 255)
        {
            _r = 255;
        }
        float _b = c.b;
        _b += v;
        if (_b >= 255)
        {
            _b = 255;
        }
        float _g = c.g;
        _g += v;
        if (_g >= 255)
        {
            _g = 255;
        }
        return new Color32((byte)_r, (byte)_g, (byte)_b, 255);
    }
}
