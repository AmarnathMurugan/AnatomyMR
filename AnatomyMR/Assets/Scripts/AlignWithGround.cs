using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System;
public class AlignWithGround : MonoBehaviour
{
    public GameObject human,MRI,MRI_Ref;
    public  bool snp=false;
    private Vector3 targetPosition;
    public Fadein fadeComp;

    public void Update()
    {

        if(snp==true)
        {
        RaycastHit hit;
        if (Physics.Raycast(human.transform.position, -Vector3.up, out hit))
        {
           targetPosition = hit.point;
            if (transform.GetComponent<MeshFilter>() != null)
            {
                    Bounds bounds = transform.GetComponent<BoxCollider>().bounds;
                
                targetPosition.y += bounds.extents.y;

            }
                human.transform.position = targetPosition;
                if (human.transform.position == targetPosition)
                {
                    human.SetActive(true);
                    MRI.transform.position = MRI_Ref.transform.position;
                    MRI.transform.rotation = MRI_Ref.transform.rotation;
                    Quaternion upRotation = Quaternion.FromToRotation(MRI.transform.up, Vector3.up);
                    MRI.transform.rotation = upRotation * MRI.transform.rotation;
                    fadeComp.startFadein = true;
                    fadeComp.FadeMat = true;
                    snp = false;
                }
            }
            

        }
        
    }
    public void getsnp(bool snpp)
    {
        snp = snpp;
    }

    


}