using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    
    
	// Use this for initialization
	void Start () {
        //Debug.Log(MusicCont);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void intr_response ()
    {
        Debug.Log("I am a " + this + ".");
        //MusicCont.TalkToSPOODERMusicOn();
        GetComponent<ActivateTextAtLine>().RunText();
        //MusicCont.BGMMusicOn();
    }
}
