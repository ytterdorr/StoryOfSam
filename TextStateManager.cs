using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextStateManager : MonoBehaviour {

    private ActivateTextAtLine activateTextAtLine;

    public TextAsset stateFile;
    public string[] stateLines;

    public Dictionary<int, int[]> stateDict = new Dictionary<int, int[]>();

	// Use this for initialization
	void Start () {
        activateTextAtLine = GetComponent<ActivateTextAtLine>();

        if (stateFile != null)
        {
            stateLines = (stateFile.text.Split('\n'));
        }

        for (int i = 0; i < stateLines.Length; i++)
        {
            //stateDict.Add(stateLines[i], 
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
