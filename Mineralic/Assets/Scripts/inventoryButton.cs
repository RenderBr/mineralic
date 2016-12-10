using UnityEngine;
using System.Collections;

public class inventoryButton : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    public GameObject[] tileGUI = new GameObject[7];
    public GameObject[] freeSlots = new GameObject[19];
    public GameObject[] craftAble = new GameObject[2];
    public bool full;
    public bool isShowing;
    public int used = 0;

    void Start()
    {
        for (int i = 0; i < freeSlots.Length; i++)
        {
            freeSlots[i] = null;
        }
    }

    public bool AddInventory(GameObject go)
    {
        for (int i = 0; i < freeSlots.Length; i++)
        {
            if (freeSlots[i] == go) return false;
            if (freeSlots[i] == null)
            {
                freeSlots[i] = go;
                return true;
            }
        }

        return false;
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            if (GetComponent<Inventory>().counts[0] >= 1)
            {

                if (AddInventory(tileGUI[0]))
                {
                    tileGUI[0].SetActive(true);
                    used++;
                }

            }

            if (GetComponent<Inventory>().counts[1] >= 1)
            {
                if (AddInventory(tileGUI[1]))
                {
                    tileGUI[1].SetActive(true);
                    used++;
                }

            }

            if (GetComponent<Inventory>().counts[3] >= 1)
            {
                if (AddInventory(tileGUI[2]))
                {
                    tileGUI[2].SetActive(true);
                    used++;
                }
            }

            if (GetComponent<Inventory>().counts[6] >= 1)
            {
                if (AddInventory(tileGUI[3]))
                {
                    tileGUI[3].SetActive(true);
                    used++;
                }
            }

            if (GetComponent<Inventory>().counts[5] >= 1)
            {
                if (AddInventory(tileGUI[4]))
                {
                    tileGUI[4].SetActive(true);
                    used++;
                }
            }

            if (GetComponent<Inventory>().counts[4] >= 1)
            {
                if (AddInventory(tileGUI[5]))
                {
                    tileGUI[5].SetActive(true);
                    used++;
                }
            }

            if (GetComponent<Inventory>().counts[7] >= 1)
            {
                if (AddInventory(tileGUI[6]))
                {
                    tileGUI[6].SetActive(true);
                    used++;
                }
            }
            if (GetComponent<Inventory>().counts[8] >= 1)
            {
                if (AddInventory(tileGUI[7]))
                {
                    tileGUI[7].SetActive(true);
                    used++;
                }
            }
            if (GetComponent<Inventory>().counts[0] >= 4)
            {
                craftAble[0].SetActive(true);
            }
            int x = 150;
            int inc = 102;
            for (int i = 0; i < freeSlots.Length; i++)
            {

                int y = 250;
                int yy = 352;
                if (freeSlots[i] != null)
                {
                    if (used < 5)
                    {
                        freeSlots[i].transform.position = new Vector3(x + (i * inc), y);
                    }
                    else if (used > 5)
                    {
                        freeSlots[i].transform.position = new Vector3(x + (i * inc), y);
                    }
                }

            }
        }
    }

    public void craftStone()
    {
        if(GetComponent<Inventory> ().counts[0] >= 4)
        {
            GetComponent<Inventory>().counts[0] -= 4;
            GetComponent<Inventory>().counts[8] += 1;
            if (GetComponent<Inventory>().counts[0] >= 4)
            {
                gameObject.SetActive(false);
            }
        }
    }
}