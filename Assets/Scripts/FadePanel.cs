using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {
	public float fadeTimeSeconds;
	public float fadeStartDelaySeconds;
	public Color fadeStartColor;
	public Color fadeEndColor;
	private Color newColor;
	private float timePassed;
	private float aPerSec;
	private float rPerSec;
	private float gPerSec;
	private float bPerSec;
	private Image img;
	private const float MIN_FADE_TIME = .01f; //don't make this zero, or negative. Bad things will happen.

	// Use this for initialization
	void Start () {
		if (fadeTimeSeconds < MIN_FADE_TIME){
			fadeTimeSeconds = MIN_FADE_TIME;
		}
		timePassed = 0f;
		aPerSec = (fadeEndColor.a - fadeStartColor.a)/fadeTimeSeconds;
		rPerSec = (fadeEndColor.r - fadeStartColor.r)/fadeTimeSeconds;
		gPerSec = (fadeEndColor.g - fadeStartColor.g)/fadeTimeSeconds;
		bPerSec = (fadeEndColor.b - fadeStartColor.b)/fadeTimeSeconds;
		img = GetComponent<Image>();
		img.color = fadeStartColor;
		newColor = img.color;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if(timePassed >= fadeStartDelaySeconds){
			newColor = UpdateAlpha(newColor, aPerSec);
			newColor = UpdateRed(newColor, rPerSec);
			newColor = UpdateGreen(newColor, gPerSec);
			newColor = UpdateBlue(newColor, bPerSec);
		}
	
		img.color = newColor;
		//Don't need. Just set image to not be raycast target
		// if (timePassed >= (fadeTimeSeconds + fadeStartDelaySeconds)){
		// 	Destroy(gameObject);
		// }
	}

	Color UpdateAlpha (Color col, float increment) {
		col.a += increment * Time.deltaTime;
		return col;
	}

	Color UpdateRed(Color col, float increment){
		col.r += increment * Time.deltaTime;
		return col;
	}

	Color UpdateGreen(Color col, float increment){
		col.g += increment * Time.deltaTime;
		return col;
	}

	Color UpdateBlue(Color col, float increment){
		col.b += increment * Time.deltaTime;
		return col;
	}

	//need to fade music too
}
