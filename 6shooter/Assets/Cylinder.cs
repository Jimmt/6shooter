using UnityEngine;
using System.Collections;

public class Cylinder : MonoBehaviour {
    public bool filled;
    Barrel barrel;
    Sprite bulletSprite;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        barrel = GetComponentInParent<Barrel>();
        renderer = GetComponent<SpriteRenderer>();
        bulletSprite = renderer.sprite;
        renderer.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown() {
        if (barrel.isOut) {
            filled = true;
            renderer.color = Color.white;
        }
    }

    public bool Expel() {
        if (!filled) {
            print("blank");
            return false;
        } else {
            print("shot");
            Eject();
            return true;
        }
    }

    void Eject() {
        filled = false;
        renderer.color = Color.clear;
    }
}
