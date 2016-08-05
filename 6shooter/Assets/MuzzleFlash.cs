using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {
    public float flashTime;
    bool flash;
    float currentFlashTime;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.clear;
    }

    // Update is called once per frame
    void Update() {
        if (flash) {
            currentFlashTime += Time.deltaTime;
            if (currentFlashTime > flashTime) {
                flash = false;
                renderer.color = Color.clear;
                currentFlashTime = 0;
            }
        }
    }

    public void Flash() {
        currentFlashTime = 0;
        renderer.color = Color.white;
        flash = true;
    }
}
