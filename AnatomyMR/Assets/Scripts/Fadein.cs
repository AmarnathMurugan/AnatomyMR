using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
public class Fadein : MonoBehaviour {
    public bool startFadein = false,boneFaded=false,MuscleFaded=false,FadeMat=false;
    public Material bone,boneFade, muscle,muscleFade;
    public Renderer bones, muscles;
    public float alpha=0.001f,MatSpeed=1.0f;
    public BlinkObject UI;
    public Material HoloScan,occlusion;
    public Transform cam;
    public SpatialMappingManager SpatialMapping;
    
	void Start ()
    {
        HoloScan.EnableKeyword("_Center");
	}
	
	
	void Update ()
    {
        if (SpatialMapping.SurfaceMaterial == HoloScan)
        {

            HoloScan.SetVector("_Center", new Vector4(cam.position.x, cam.position.y, cam.position.z, 0));
        }

        if (boneFade.color.a < 1 && startFadein == true)
                    boneFade.color+= new Color(0.0f,0.0f,0.0f, alpha);                
        if (boneFade.color.a >= 1 && startFadein == true)
        {         
            bones.material = bone;
            startFadein = false;
            boneFaded = true;
        }    

        if(muscleFade.color.a<1 && boneFaded==true)
            muscleFade.color += new Color(0.0f, 0.0f, 0.0f, alpha);
        if (muscleFade.color.a >= 1 && boneFaded == true)
        {
            muscles.material = muscle;
            boneFaded = false;
            MuscleFaded = true;
        }
        if (MuscleFaded)
        {
            UI.spawn(0);
            MuscleFaded = false;
           
        }

        if(FadeMat)
        {
            HoloScan.color = new Color(0, Mathf.MoveTowards(HoloScan.color.g, 0.0f, Time.deltaTime * MatSpeed), Mathf.MoveTowards(HoloScan.color.b, 0.0f, Time.deltaTime * MatSpeed));
            if (HoloScan.color == new Color(0, 0, 0))
            {
                FadeMat = false;
                SpatialMapping.SurfaceMaterial = occlusion;
            }
        }
    }
}
