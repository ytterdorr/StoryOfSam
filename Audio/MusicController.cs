using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioMixerSnapshot BGMSnap;
    public AudioMixerSnapshot TalkToSPOODERSnap;

    public AudioClip[] TalkToSPOODERAudio;
    public AudioSource TalkToSPOODERSource;

    public float bpm = 75f;

    private float m_transitionIn;
    private float m_transitionOut;
    private float m_quarterNote;

	// Use this for initialization
	void Start () {
        m_quarterNote = 60 / bpm;
        m_transitionIn = 1;
        m_transitionOut = m_quarterNote * 4;
	
	}
	
    public void TalkToSPOODERMusicOn()
    {
        TalkToSPOODERSnap.TransitionTo(m_transitionIn);
    }

    public void BGMMusicOn()
    {
        BGMSnap.TransitionTo(m_transitionOut);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
