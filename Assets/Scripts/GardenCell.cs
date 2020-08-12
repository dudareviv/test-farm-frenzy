using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenCell : MonoBehaviour
{
    public GardenGrid Grid
    {
        get { return _grid; }
        set { _grid = value; }
    }

    private GardenGrid _grid;

}
