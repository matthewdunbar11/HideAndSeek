using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManagement : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isServer)
			return;

		InvokeRepeating ("StartGameTimer", 1.0f, 1.0f);
	}

	void StartGameTimer() {

	}
}