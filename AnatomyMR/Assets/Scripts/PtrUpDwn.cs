using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PtrUpDwn : MonoBehaviour
{
    public int size;
    public float speed=1.0f;
    public bool EditOrgans = true;
    public GameObject Organs;
    public GameObject[] obj=new GameObject[3];
    public Material[] OrgMat, TransparentMat;
    private Renderer[] rend=new Renderer[3];
    private bool StartTransparentIn=false,StartTransparentOut=false;
    private float alpha = (float)(70 / 255);

    private void Start()
    {
        for (int i = 0; i < size; i++)
        { 
             var temp = OrgMat[i].color;
             temp.a = 1.0f;
             TransparentMat[i].color = temp;
             rend[i] = obj[i].GetComponent<Renderer>();
         }
    }

    private void Update()
    {
        for (int i = 0; i < size; i++)
        {
            if (StartTransparentIn && rend[i].material.color.a != alpha)
            {
                rend[i].material.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f * speed);
                if (rend[i].material.color.a <= alpha)
                    StartTransparentIn = false;
            }
        }

        
        /*    if (StartTransparentOut )
            {
                    StartTransparentOut = false;
                    for (int i = 0; i < size; i++) 
                        rend[i].material = OrgMat[i];
            } */
        

    }

   

    public void PtrEnter()
    {
        for (int i = 0; i < size; i++)
            rend[i].material = OrgMat[i];
        for (int i = 0; i < size; i++)
        {
            var temp = OrgMat[i].color;
            temp.a = 1.0f;
            TransparentMat[i].color = temp;
            rend[i].material = TransparentMat[i];
        }
        if(EditOrgans)
        Organs.SetActive(false);
        StartTransparentIn = true;
    }

    public void PtrExit()
    {
        if (EditOrgans)
            Organs.SetActive(true);
        for (int i = 0; i < size; i++)
            rend[i].material = OrgMat[i];
        StartTransparentOut = true;
    }

    private void OnMouseOver()
    {
        Debug.Log("On element!");
        if(!StartTransparentIn)
        {
            for (int i = 0; i < size; i++)
                rend[i].material = OrgMat[i];
            for (int i = 0; i < size; i++)
            {
                var temp = OrgMat[i].color;
                temp.a = 1.0f;
                TransparentMat[i].color = temp;
                rend[i].material = TransparentMat[i];
            }
            if (EditOrgans)
                Organs.SetActive(false);
            StartTransparentIn = true;
        }
    }

}
