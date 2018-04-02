using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIraycastName : MonoBehaviour {
    public Renderer Muscles, Skeleton;
    public Material MusMat, SkeMat;
    public static string UIobj;
    private string Prev_Name = "NULL";
    private bool EnteredButton = false;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if (UIobj.CompareTo("Isl_Organs") == 0 || UIobj.CompareTo("Isl_Bones") == 0 || UIobj.CompareTo("Isl_Muscles") == 0)
        {
            EnteredButton = true;
            Prev_Name = UIobj;
        }
       
        if(EnteredButton && Prev_Name!=UIobj)
        {
            EnteredButton = false;
            StartCoroutine(ChangeMat());
        }
           
	}

    IEnumerator ChangeMat()
    {
        yield return new WaitForSeconds(1.0f);
        if (Muscles.material != MusMat)
            Muscles.material = MusMat;
        if (Skeleton.material != SkeMat)
            Skeleton.material = SkeMat;
    }
}
