using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour {

    int currentGameObject = 0;
    int totalGameObjects;
	// Use this for initialization
	void Start () {
        totalGameObjects = transform.GetChildCount();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.GetChild(currentGameObject).gameObject.SetActive(false);
            currentGameObject++;
            if(currentGameObject >= totalGameObjects)
            {
                currentGameObject = 0;
            }

            transform.GetChild(currentGameObject).gameObject.SetActive(true);
        }

    }
}
