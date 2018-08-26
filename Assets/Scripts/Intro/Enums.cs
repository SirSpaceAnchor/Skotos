using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Numbers { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Display, Clear };

public static class Enums
{
    public static string NumberString(Numbers Num)
    {
        switch (Num)
        {
            case Numbers.One:
                return "A, B, C";
            case Numbers.Two:
                return "D, E, F";
            case Numbers.Three:
                return "G, H, I";
            case Numbers.Four:
                return "J, K, L";
            case Numbers.Five:
                return "M, N, O";
            case Numbers.Six:
                return "P, Q, R";
            case Numbers.Seven:
                return "S, T, U";
            case Numbers.Eight:
                return "V, W, X";
            case Numbers.Nine:
                return "Y, Z";
            case Numbers.Display:
                return "";
            case Numbers.Clear:
                return "Clear";
            case Numbers.Zero:
            default:
                return "";
        }
    }

    public static int Number(Numbers NUm)
    {
        switch (NUm)
        {
            case Numbers.One:
                return 1;
            case Numbers.Two:
                return 2;
            case Numbers.Three:
                return 3;
            case Numbers.Four:
                return 4;
            case Numbers.Five:
                return 5;
            case Numbers.Six:
                return 6;
            case Numbers.Seven:
                return 7;
            case Numbers.Eight:
                return 8;
            case Numbers.Nine:
                return 9;
            case Numbers.Zero:
            default:
                return 0;
        }
    }
}