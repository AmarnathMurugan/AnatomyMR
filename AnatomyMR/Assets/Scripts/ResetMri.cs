using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMri : MonoBehaviour {

    public Transform MRI,temp;
    

  
    public void SetTransform()
    {
        MRI.position = temp.position;
        MRI.rotation = temp.rotation;
        MRI.localScale = temp.localScale;
    }
}
