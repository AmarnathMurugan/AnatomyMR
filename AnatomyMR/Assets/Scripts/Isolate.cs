using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class Isolate : MonoBehaviour {

    public int size;
    public TextToSpeechManager txt2Speech;
    public float speed1 = 1.0f,speed2=2.0f;
    public GameObject Organs;
    public bool EditOrgans = true;
    public GameObject[] obj = new GameObject[3];
    public Material[] OrgMat, FadeMat;
    private Renderer[] rend = new Renderer[3];
    private bool StartIsolation = false, StartDeisolation = false;

    void Start ()
    {
        for (int i = 0; i < size; i++)
        {
            var temp = OrgMat[i].color;
            temp.a=(float)(70/255);
            FadeMat[i].color = temp;
            rend[i] = obj[i].GetComponent<Renderer>();
        }
    }
	

	void Update ()
    {
        if (StartIsolation && Organs.activeSelf && EditOrgans)
            Organs.SetActive(false);

        for (int i = 0; i < size; i++)
        {
            if (StartIsolation && rend[i].material.color.a >= 0.0f)
            {
                rend[i].material.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f * speed1);
                if (rend[i].material.color.a <= 0.0f)
                {
                    for ( i = 0; i < size; i++)
                        obj[i].SetActive(false);
                    StartIsolation = false;
                }
            }
        }


        for (int i = 0; i < size; i++)
        {
            if (StartDeisolation && rend[i].material.color.a != 1.0f)
            {
                if(!obj[i].activeSelf)
                    obj[i].SetActive(true);
                rend[i].material.color += new Color(0.0f, 0.0f, 0.0f, 0.1f * speed2);
                if (rend[i].material.color.a >= 1.0f)
                {
                    StartDeisolation = false;
                    for (i = 0; i < size; i++)
                        rend[i].material = OrgMat[i];


                }
            }
        }

        if (StartDeisolation && !Organs.activeSelf && EditOrgans)
            Organs.SetActive(true);


    }

    public void isolate(string str)
    {
        for (int i = 0; i < size; i++)
        {
            var temp = OrgMat[i].color;
            //temp.a = (float)(70 / 255);
            temp.a = 0.1f;
            FadeMat[i].color = temp;
            rend[i].material = FadeMat[i];
        }
        StartIsolation = true;
        txt2Speech.SpeakText(str + " isolated");
    }

    public void deisolate()
    {
        StartDeisolation = true;
    }

}
