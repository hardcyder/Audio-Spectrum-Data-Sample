using UnityEngine;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
		
	public Transform[] audioSpectrumObjects;
	public float heightMultiplier;
	public int numberOfSamples = 1024;
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	
	void Update() {

		// initialize our float array
		float[] spectrum = new float[numberOfSamples];

		// populate array with fequency spectrum data
		GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);


		// loop over audioSpectrumObjects and modify according to fequency spectrum data
		// this loop matches the Array element to an object on a One-to-One basis.
		for(int i = 0; i < audioSpectrumObjects.Length; i++)
		{

			// apply height multiplier to intensity
			float intensity = spectrum[i] * heightMultiplier;

			// calculate object's scale
			float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y,intensity,lerpTime);
			Vector3 newScale = new Vector3( audioSpectrumObjects[i].localScale.x, lerpY, audioSpectrumObjects[i].localScale.z);

			// appply new scale to object
			audioSpectrumObjects[i].localScale = newScale;

		}
	}

}
