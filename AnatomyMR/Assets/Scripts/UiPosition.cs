using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UiPosition : MonoBehaviour {

    public RectTransform UI;
    public GameObject UpButton, DownButton;
    public float speed = 1.0f;
    private Vector3 target=new Vector3(0,-90,0);
    private Vector3 Origin = new Vector3(0, -30, 0);
    private bool GoDown=false, GoUp=false;
	

	void Update ()
    {
		if(GoDown && UI.position!=target)
        {
            UI.localPosition = Vector3.MoveTowards(UI.localPosition, target, Time.deltaTime * speed);
            if(UI.localPosition==target)
            {
                GoDown = false;
                
                UpButton.SetActive(true);
            }
        }

        if (GoUp && UI.position != Origin)
        {
            UI.localPosition = Vector3.MoveTowards(UI.localPosition, Origin, Time.deltaTime * speed);
            if (UI.localPosition == Origin)
            {
                UI.localPosition = Origin;
                GoUp =false;
              
                DownButton.SetActive(true);
            }
        }




    }

    public void down()
    {
        GoDown = true;
        DownButton.SetActive(false);
    }

    public void up()
    {
        GoUp = true;
        UpButton.SetActive(false);
    }
}
