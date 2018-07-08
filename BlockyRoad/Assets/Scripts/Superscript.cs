using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Superscript
{
    public static int TilEmpty = 0;

    public static void SaveString(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
    }

    public static string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

}
