using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Superscript
{
    public static int TilEmpty = 0;

    public static void SaveInt(int value)
    {
        PlayerPrefs.SetInt("coins", value);
    }
}
