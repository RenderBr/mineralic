using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventorySystem : MonoBehaviour
{

    public Text selectionText;

    public int[] counts = new int[8];

    public int[] possibleCounts = new int[7];

    int selectedTile;

    string[] names = new string[] { "Stone", "Dirt", "Coal", "Diamond", "Gold", "Iron", "Glass" };

    public GameObject[] tiles = new GameObject[7];

    public Text[] tileCounts = new Text[7];

    void Update()
    {
        if (selectedTile < 0)
        {
            selectedTile = possibleCounts.Length - 1;
        }

        if (selectedTile > possibleCounts.Length - 1)
        {
            selectedTile = 0;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            selectedTile++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            selectedTile--;
        }

        selectionText.text = "Selected: " + names[selectedTile];

        if (Input.GetMouseButtonDown(1))
        {
            if (possibleCounts[selectedTile] > 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 placePos = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f);

                if (Physics2D.OverlapCircleAll(placePos, 0.25f).Length == 0)
                {
                    GameObject newTile = Instantiate(tiles[selectedTile], placePos, Quaternion.identity) as GameObject;
                    counts[selectedTile]--;
                }
            }
        }

        if (selectedTile == 1)
            if (Input.GetKeyDown(KeyCode.C))
            {
                {
                    if (counts[1] >= 2)
                    {
                        counts[7]++;
                        counts[1] -= 2;
                    }
                }
            }
    }
    public void Add(int tileType, int count)
    {
        counts[tileType] += count;
    }
}