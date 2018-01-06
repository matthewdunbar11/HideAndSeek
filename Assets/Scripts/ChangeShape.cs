using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeShape : NetworkBehaviour {

    int currentGameObject = 0;
    int totalGameObjects;
	// Use this for initialization
	void Start () {
        totalGameObjects = transform.childCount;
    }
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentGameObject++;
            if(currentGameObject >= totalGameObjects)
            {
                currentGameObject = 0;
            }

			CmdSwitchVisibleChild (currentGameObject);
//			RpcSwitchVisibleChild (currentGameObject);
			SwitchVisibleChild (currentGameObject);
        }

    }

	[Command]
	void CmdSwitchVisibleChild(int index) {
		RpcSwitchVisibleChild (index);
	}

	[ClientRpc]
	void RpcSwitchVisibleChild(int index) {
		SwitchVisibleChild (index);
	}

	void SwitchVisibleChild(int index) {
		for (var i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SetActive (false);
		}
		transform.GetChild (index).gameObject.SetActive (true);		
	}
}
