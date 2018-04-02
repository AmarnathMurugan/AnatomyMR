using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject PositionProxy, Ui;
	void Start () {
		
	}
	
	
	void LateUpdate ()
    {
        Ui.transform.position = PositionProxy.transform.position;	
	}
}
