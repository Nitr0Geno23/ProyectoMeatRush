using UnityEngine;
using System.Collections;



public class ColorRamp : MonoBehaviour {

	public AudioSource sfx;
	public float speed = 375f;

	private RectTransform rt;
	private float movement;


	void Start () {
		rt = GetComponent<RectTransform>();
	}


    void Update () {
		if (rt.anchoredPosition.x <= 200) {
			movement = -speed * Time.deltaTime;
			rt.localPosition = new Vector3 (rt.localPosition.x, rt.localPosition.y - movement, rt.localPosition.z);
		}

		if (rt.anchoredPosition.x >= 120 && rt.anchoredPosition.x <= 130) {
			if (!sfx.isPlaying) {
				sfx.Play();
			}
		}

	}
}

