using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
    Vector3 startingPosition;
    float t;
    float shakeX, shakeY;
    int multiplier;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        t += multiplier * 40 * 1 / 60f;
        t = Mathf.Clamp(t, 0, 1);
        transform.position = startingPosition + new Vector3(Mathf.Lerp(0, shakeX, t), Mathf.Lerp(0, shakeY, t), 0);

        if(t == 1) {
            multiplier = -1;
        }
	}

    public void Shake() {
        startingPosition = transform.position;
        multiplier = 1;
        t = 0;
        shakeX = Random.Range(-0.2f, 0.2f);
        shakeY = Random.Range(-0.2f, 0.2f);
    }
}
