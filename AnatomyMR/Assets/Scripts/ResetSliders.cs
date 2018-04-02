using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetSliders : MonoBehaviour {
    public Slider slider1, slider2;
	
    public void ResetVal()
    {
        slider1.value = 0;
        slider2.value = 0;
    }
}
