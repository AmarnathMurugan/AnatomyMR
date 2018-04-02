using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MriHumanTr : MonoBehaviour {

    public BoxCollider Col;
    public GameObject MRI, Human, organs,MriParent,MriRef;
    public Renderer Muscles, Skeleton;
    public Material[] MriMats=new Material[226];
    public Material Bone, Muscle,BoneFade,MuscleFade;
    public BlinkObject MainUi, MriUi;
    public float speed = 1.0f, MriSpeed = 1.0f, RotSpeed = 1.0f, scaleSpeed = 1,MoveSpeed=1;
    public Slider F2B, B2F;  
    private bool M2H = false, H2M=false;
    private bool isRotated = false, isMriFaded = false, isHumanFaded = false, isScaled = false, isPositionSet = false, isParentRotated = false;
    private Vector3 InitSize = new Vector3(0.4365491f, 0.4873932f, 0.5372909f);

    void Start ()
    {
       
        for (int i = 0; i < 226; i++)
            MriMats[i].EnableKeyword("_Cutoff");
	}
	
	
	void Update ()
    {
	    if(H2M)
        {
            if(!isMriFaded)
                for (int i = 0; i < 226; i++)
                {
                    MriMats[i].SetFloat("_Cutoff", Mathf.MoveTowards(MriMats[i].GetFloat("_Cutoff"), 0.04f,Time.deltaTime*MriSpeed));
                }
            if (MriMats[225].GetFloat("_Cutoff") <= 0.04f)
                isMriFaded = true; 
            if(MuscleFade.color.a>=0 && BoneFade.color.a>=0)
            {
                MuscleFade.color -= new Color(0, 0, 0, 1 * speed);
                BoneFade.color -= new Color(0, 0, 0, 1 * speed);
            
            }
            if (BoneFade.color.a <= 0.03f && MuscleFade.color.a <= 0.03f)
            {
                MuscleFade.color = new Color(MuscleFade.color.r, MuscleFade.color.g, MuscleFade.color.b, 0);
                BoneFade.color = new Color(BoneFade.color.r, BoneFade.color.g, BoneFade.color.b, 0);
                isHumanFaded = true;
            }

            if (isMriFaded && isHumanFaded)
            {
               
                MRI.transform.localRotation = Quaternion.RotateTowards(MRI.transform.localRotation, Quaternion.Euler(0,-90,0), Time.deltaTime * RotSpeed);
             
                if (MRI.transform.localRotation == Quaternion.Euler(0, -90, 0))
                {
               
                    isRotated = true;
                    isMriFaded = false;
                    isHumanFaded = false;
                }
            }
            if (isRotated==true)
            {
                Human.SetActive(false);
                MriUi.spawn();

                Col.enabled = true;
                H2M = false;
                isRotated = false;
               
            }


        }
        
        if(M2H)
        {
            if(!isRotated)
                MRI.transform.localRotation = Quaternion.RotateTowards(MRI.transform.localRotation, Quaternion.Euler(-90, 0, 0), Time.deltaTime * RotSpeed);
     
            if (MRI.transform.localRotation== Quaternion.Euler(-90, 0, 0))
            {
                MRI.transform.localRotation = Quaternion.Euler(-90, 0, 0);
               isRotated = true;
            }
            if (MriParent.transform.localScale != InitSize)
                MriParent.transform.localScale = Vector3.MoveTowards(MriParent.transform.localScale, InitSize, Time.deltaTime * scaleSpeed);
            else if (MriParent.transform.localScale == InitSize)
                isScaled = true;
            if (MriParent.transform.position != MriRef.transform.position)
                MriParent.transform.position = Vector3.MoveTowards(MriParent.transform.position, MriRef.transform.position, Time.deltaTime * MoveSpeed);
            else if (MriParent.transform.position == MriRef.transform.position)
                isPositionSet = true;
            if (MriParent.transform.rotation != MriRef.transform.rotation)
                MriParent.transform.rotation = Quaternion.RotateTowards(MriParent.transform.localRotation, MriRef.transform.rotation, Time.deltaTime * RotSpeed);
            else
                isParentRotated = true;
            if (isRotated && isPositionSet && isScaled && isParentRotated )
            {
                if (!isMriFaded)
                    for (int i = 0; i < 226; i++)
                    {
                        MriMats[i].SetFloat("_Cutoff", Mathf.MoveTowards(MriMats[i].GetFloat("_Cutoff"), 1, Time.deltaTime * MriSpeed));
                    }
                if (MriMats[225].GetFloat("_Cutoff") ==1)
                {
                    isMriFaded = true;
                    MriParent.SetActive(false);
                }

                if (MuscleFade.color.a <= 1 && BoneFade.color.a <= 1)
                {
                    MuscleFade.color += new Color(0, 0, 0, 1 * speed);
                    BoneFade.color += new Color(0, 0, 0, 1 * speed);
                }
                if (BoneFade.color.a >= 0.98f && MuscleFade.color.a >= 0.98f)
                {
                    MuscleFade.color = new Color(MuscleFade.color.r, MuscleFade.color.g, MuscleFade.color.b, 1);
                    BoneFade.color = new Color(BoneFade.color.r, BoneFade.color.g, BoneFade.color.b, 1);
                    Muscles.material = Muscle;
                    Skeleton.material = Bone;
                    isHumanFaded = true;
                    isParentRotated = false;
                }


            }

            if (isMriFaded && isHumanFaded)
            {
                organs.SetActive(true);
                MainUi.spawn();
                isRotated = false; isPositionSet = false;  isScaled = false;
                for (int i = 0; i < 226; i++)
                {
                    MriMats[i].SetFloat("_Cutoff", 0.04f);
                }
                M2H = false;
                isMriFaded = false;
                isHumanFaded = false;


            }
        }    	
    


	}

    public void HumanToMri()
    {
        Muscles.material = Muscle;
        Skeleton.material = Bone;
        Col.enabled = false;
        organs.SetActive(false);
        MainUi.close();
        for(int i=0;i<226;i++)
        {
            MriMats[i].SetFloat("_Cutoff", 1.0f);
        }
        MuscleFade.color = new Color(MuscleFade.color.r, MuscleFade.color.g, MuscleFade.color.b, 1);
        BoneFade.color = new Color(BoneFade.color.r, BoneFade.color.g, BoneFade.color.b, 1);
        Muscles.material = MuscleFade;
        Skeleton.material = BoneFade;
        MriParent.SetActive(true);
        H2M = true;
    }

    public void MriToHuman()
    {
        MuscleFade.color = new Color(MuscleFade.color.r, MuscleFade.color.g, MuscleFade.color.b, 0);
        BoneFade.color = new Color(BoneFade.color.r, BoneFade.color.g, BoneFade.color.b, 0);
        Muscles.material = MuscleFade;
        Skeleton.material = BoneFade;
        Col.enabled = false;
        Human.SetActive(true);
        MriUi.close();
        F2B.value = 0;
        B2F.value = 0;
        M2H = true;

    }
}
