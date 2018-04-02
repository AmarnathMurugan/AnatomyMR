using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkObject : MonoBehaviour {

    public GameObject element;
    public float sec=0.05f, delaySpn=0.0f, delayExt=0.0f;
    public bool spn = false, ext = false;
	
	
	void Update ()
    {
        if (spn)
        {
         
            StartCoroutine(blinkobj());
            spn = false;
        }
        if (ext)
        {
            StartCoroutine(blinkobjexit());
            ext = false;
        }
    }

    public void spawn(float delay=0.0f)
    {

        spn = true;
        delaySpn = delay;

    }

    public void close(float delay=0.0f)
    {
        ext = true;
        delayExt = delay;

    }

    IEnumerator blinkobj()
    {
        yield return new WaitForSeconds(delaySpn);
        element.SetActive(true);
        yield return new WaitForSeconds(sec);
        element.SetActive(false);
        yield return new WaitForSeconds(sec * 2.0f);
        element.SetActive(true);
    }

    IEnumerator blinkobjexit()
    {
        yield return new WaitForSeconds(delayExt);
        element.SetActive(false);
        yield return new WaitForSeconds(sec * 1.2f);
        element.SetActive(true);
        yield return new WaitForSeconds(sec);
        element.SetActive(false);
    }
}
