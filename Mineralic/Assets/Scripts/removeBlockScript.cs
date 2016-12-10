using UnityEngine;
using System.Collections;

public class removeBlockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
        Debug.Log("Collided");
    }
}
