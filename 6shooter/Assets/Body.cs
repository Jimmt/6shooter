using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {
    public SpriteRenderer renderer;
    public Vector3 sightPoint;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        sightPoint = new Vector3();
        FindSightPoint();
	}

    void FindSightPoint() {
        float y = transform.position.y + renderer.bounds.size.y / 2f;
        float x = transform.position.x;
        sightPoint.Set(x, y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        FindSightPoint();
    }
}
