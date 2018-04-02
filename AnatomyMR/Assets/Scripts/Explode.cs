using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public bool explode = false;
    public float speed = 1.0f;
    public Transform Skeleton, Muscles,Ske_ref,Mus_ref,Ske_init,Mus_init;
  

	
	void Update ()
    {
		if(explode && Skeleton.position!=Ske_ref.position && Muscles.position!=Mus_ref.position)
        {
            Skeleton.position = Vector3.MoveTowards(Skeleton.position, Ske_ref.position, Time.deltaTime*speed);
            Muscles.position = Vector3.MoveTowards(Muscles.position, Mus_ref.position, Time.deltaTime * speed);
        }
        if(explode==false && Skeleton.position != Ske_init.position && Muscles.position != Mus_init.position)
        {
            Skeleton.position = Vector3.MoveTowards(Skeleton.position, Ske_init.position, Time.deltaTime * speed);
            Muscles.position = Vector3.MoveTowards(Muscles.position, Mus_init.position, Time.deltaTime * speed);
           

        }
   
           

    }

    public void getbool(bool x)
    {
        explode = x;
    }
}
