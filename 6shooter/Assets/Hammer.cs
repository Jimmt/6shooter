using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {
    public bool cocked;
    GameObject primarySprite;
    public Vector3 startingPosition;
    public float hammerSpeed;
    int hammerDirection;
    float hammerT;
    float height;

    // Use this for initialization
    void Start() {
        primarySprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        startingPosition = primarySprite.transform.position;
        height = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update() {
        hammerT += hammerDirection * hammerSpeed * Time.deltaTime;
        hammerT = Mathf.Clamp(hammerT, 0, 1);
        primarySprite.transform.position = startingPosition + new Vector3(0, Mathf.Lerp(0, -height / 2f, hammerT), 0);

        if (hammerT == 1) {
            cocked = true;
        }
    }

    public void Cock() {
        if (hammerDirection != 1) {
            GetComponentInParent<AudioSource>().PlayOneShot(SoundManager.LoadSoundClip("cock"));
        }
        hammerDirection = 1;
    }

    public void Reset() {
        hammerDirection = 0;
        hammerT = 0;
        cocked = false;
    }
}
