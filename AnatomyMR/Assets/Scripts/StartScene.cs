using System.Collections;
using HoloToolkit.Unity;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class StartScene : MonoBehaviour,IInputClickHandler
{
    public GameObject Human,proxy;
    public AlignWithGround AlignScript;
    public TextToSpeechManager txt2speech;
    public Material Bone, Muscle;
    public TextMesh IntroText;
    public Material HoloMat;
    public Color HoloCol;
    private Color OldColor;
    private Animator txtAnim;

    // private float alpha=0.0f;

    private void Awake()
    {
        HoloMat.color = HoloCol;
        txtAnim = IntroText.GetComponent<Animator>();
        //  IntroText.gameObject.SetActive(false);
        txtAnim.SetBool("trigFade", true);
        var Bone_col = Bone.color;
        Bone_col.a = 0.0f;
        Bone.color = Bone_col;
        var Mus_col = Muscle.color;
        Mus_col.a = 0.0f;
        Muscle.color = Mus_col;
    }

    void Start ()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        StartCoroutine(InitSpeech());
       


    }
	
	
	void Update ()
    {
		
	}

    public virtual void OnInputClicked(InputEventData eventData)
    {
        if (!txt2speech.IsSpeaking())
        {
            Debug.Log("Tap Gesture");
            Human.transform.position = proxy.transform.position;
            Human.transform.rotation = proxy.transform.rotation;
            AlignScript.snp = true;
           txtAnim.SetBool("trigFade", false);
            Destroy(this);
        }
    }

    IEnumerator InitSpeech()
    {
        yield return new WaitForSeconds(0.5f);
        txt2speech.SpeakText("Hello! Welcome to Human anatomy explorer . Please gaze at an empty space and air tap to start the demo");
        Debug.Log("Intro Speech");
        //yield return new WaitForSeconds(4.0f);
       // IntroText.gameObject.SetActive(true);
        //txtAnim.SetBool("trigFade", true);
    }

  
}
