using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MriScr : MonoBehaviour {

   
    public Renderer[] Slides;     
    public Slider T2B,B2T;
    private int val1, val2,maxVal,minVal;
  

    public void disableObjs1()
    {
        int val1 = (int)T2B.value;
        int val2 = (int)B2T.value;
        for (int i = 0; i < val1; i++)
            Slides[i].gameObject.SetActive(false);
        
        for(int i=val1;i<(225-val2);i++)
            Slides[i].gameObject.SetActive(true);
    }

    public void disableObjs2()
    {
        int val1 = (int)T2B.value;
        int val2 = (int)B2T.value;
        for (int i = 225; i > (225-val2); i--)
            Slides[i].gameObject.SetActive(false);
        for (int i = (225-val2); i > val1; i--)
            Slides[i].gameObject.SetActive(true);
    }
}
