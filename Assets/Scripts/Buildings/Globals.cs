using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static int Ground_Layer_Mask = 1 << 8;
    public static BuildingsData[] Building_Data = new BuildingsData[]
    {
        new BuildingsData("LumberMill", 100)

    };
}
