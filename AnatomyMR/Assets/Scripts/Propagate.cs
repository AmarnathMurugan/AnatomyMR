using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propagate : MonoBehaviour {

    public GameObject slidObj,parent;
    Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
	void Start ()
    {
        for (int i= 0;i<226;i++)
        {
            var temp = Instantiate(slidObj);
            temp.name = i.ToString();
            temp.transform.position += position;
            temp.transform.parent = parent.transform;
            position.z += 0.01f;
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
