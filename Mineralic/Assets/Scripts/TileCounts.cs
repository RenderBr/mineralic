using UnityEngine;
using System.Collections;

public class TileCounts : MonoBehaviour {

    //0 = stone, 1 = dirt, 2 = grass, 3 = coal, 4 = diamond, 5 = gold, 6 = iron, 7 = glass
    void Update () {
        if (GetComponent<Inventory> ().counts[0] > 0)
        {
            GetComponent<Inventory> ().tileCounts[0].text = "" + GetComponent<Inventory> ().counts[0];
        }

        if (GetComponent<Inventory>().counts[1] > 0)
        {
            GetComponent<Inventory>().tileCounts[1].text = "" + GetComponent<Inventory>().counts[1];

        }

        if (GetComponent<Inventory>().counts[3] > 0)
        {
            GetComponent<Inventory>().tileCounts[2].text = "" + GetComponent<Inventory>().counts[3];

        }

        if (GetComponent<Inventory>().counts[6] > 0)
        {
            GetComponent<Inventory>().tileCounts[3].text = "" + GetComponent<Inventory>().counts[6];

        }

        if (GetComponent<Inventory>().counts[5] > 0)
        {
            GetComponent<Inventory>().tileCounts[4].text = "" + GetComponent<Inventory>().counts[5];

        }

        if (GetComponent<Inventory>().counts[4] > 0)
        {
            GetComponent<Inventory>().tileCounts[5].text = "" + GetComponent<Inventory>().counts[4];

        }

        if (GetComponent<Inventory>().counts[7] > 0)
        {
            GetComponent<Inventory>().tileCounts[6].text = "" + GetComponent<Inventory>().counts[7];

        }

        if (GetComponent<Inventory>().counts[8] > 0)
        {
            GetComponent<Inventory>().tileCounts[7].text = "" + GetComponent<Inventory>().counts[8];

        }
    }
}

//0 = stone, 1 = dirt, 2 = grass, 3 = coal, 4 = diamond, 5 = gold, 6 = iron, 7 = glass, 8 = stone bricks,