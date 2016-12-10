using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    public Text inventoryText, selectionText, healthText, levelText, expText;

    public int[] counts = new int[9];

    int selectedTile;

    string[] names = new string[] {"Stone", "Dirt", "Grass", "Coal", "Diamond", "Gold", "Iron", "Glass", "Stone Brick"};

    public int startHealth = 100;

    public int startlevel = 1;

    public int level;

    public int maxexp = 5;

    public int xp = 0;

    public int currentHealth;

    public GameObject[] tiles = new GameObject[7];

    public Text[] tileCounts = new Text[8];

    void Start()
    {
        currentHealth = startHealth;
        level = startlevel;
    }

    void Update()
    {
        if (selectedTile < 0)
        {
            selectedTile = counts.Length - 1;
        }

        if (selectedTile > counts.Length - 1)
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
            if (counts[selectedTile] > 0)
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

        healthText.text = "Health: " + currentHealth;
        levelText.text = "Level: " + level;
        expText.text = xp + "/" + maxexp;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("mainmenu");
        }
        if(xp == maxexp)
        {
            xp = 0;
            Debug.Log("Level Up!");
            level += 1;
            if (level == 2){ 
            maxexp += 3;
            }
            if (level == 3)
            {
                maxexp += 5;
            }
            if (level >= 4)
            {
                maxexp += 8;
            } else
            {
                maxexp += 10;
            }
            currentHealth++;
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
        if (selectedTile == 0)
            if (Input.GetKeyDown(KeyCode.C))
            {
                {
                    if (counts[0] >= 4)
                    {
                        counts[8]++;
                        counts[0] -= 4;
                    }
                }
            }
    }
        public void Add(int tileType, int count) {
        counts[tileType] += count;
    }
} 