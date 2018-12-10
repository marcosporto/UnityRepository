using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class Volume : MonoBehaviour {

    public AudioMixer controleSom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVolume (float volume) {

        controleSom.SetFloat("volume", volume);
    }
}
