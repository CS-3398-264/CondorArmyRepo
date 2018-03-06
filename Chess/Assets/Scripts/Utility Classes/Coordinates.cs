using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordinates {

    public int x;
    public int z;

    public static Coordinates operator+ (Coordinates a, Coordinates b)
    {
        Coordinates coord = new Coordinates();
        coord.x = a.x + b.x;
        coord.z = a.z + b.z;
        return coord;
    }

    public static Coordinates operator* (Coordinates a, Coordinates b)
    {
        Coordinates coord = new Coordinates();
        coord.x = a.x * b.x;
        coord.z = a.z * b.z;
        return coord;
    }
}
