using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUI : MonoBehaviour {

    public GameObject MainUI;
    public float WaitTime = 1.0f;

    void Start () {
		
	}
	

	void Update () {
		
	}

    IEnumerator enableUI()
    {
        yield return new WaitForSeconds(WaitTime);
        MainUI.SetActive(true);
    }

    public void callroutine()
    {
        StartCoroutine(enableUI());
    }
}
