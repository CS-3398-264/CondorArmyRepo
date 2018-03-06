using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordinates {

    public int x;
    public int z;

    public Coordinates()
    {
        this.x = 0;
        this.z = 0;
    }

    public Coordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static Coordinates operator+ (Coordinates a, Coordinates b)
    {
        Coordinates coord = new Coordinates();
        coord.x = a.x + b.x;
        coord.z = a.z + b.z;
        return coord;
    }

    public static Coordinates operator -(Coordinates a, Coordinates b) {
        Coordinates coord = new Coordinates();
        coord.x = a.x - b.x;
        coord.z = a.z - b.z;
        return coord;
    }

    public static Coordinates operator* (Coordinates a, Coordinates b)
    {
        Coordinates coord = new Coordinates();
        coord.x = a.x * b.x;
        coord.z = a.z * b.z;
        return coord;
    }

    public Coordinates flip()
    {
        Coordinates coord = new Coordinates();
        coord.x = x;
        coord.z = z * -1;
        return coord;
    }

    public override string ToString() {
        return "(" + x + "," + z + ")";
    }
}
