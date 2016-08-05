using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
    public Cylinder[] cylinders;
    public bool isOut, rotating;
    public float popT, popSpeed;
    public float rotateT, rotateSpeed;
    int popDirection, rotateDirection;
    float width;
    public Vector3 startingPosition;
    float startingRotationZ;

    // Use this for initialization
    void Start() {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        startingPosition = transform.position;
        startingRotationZ = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update() {
        TrackPop();
        TrackRotation();
    }

    public Cylinder GetCurrentCylinder() {
        int maxIndex = 0;
        for(int i = 0; i < cylinders.Length; i++) {
            if(cylinders[i].transform.position.y > cylinders[maxIndex].transform.position.y) {
                maxIndex = i;
            }
        }
        return cylinders[maxIndex];
    }

    void TrackPop() {
        popT += popDirection * popSpeed * Time.deltaTime;
        popT = Mathf.Clamp(popT, 0, 1);
        transform.position = startingPosition + Vector3.right * Mathf.Lerp(0, width, popT);
    }

    void TrackRotation() {
        rotateT += rotateDirection * rotateSpeed * Time.deltaTime;
        rotateT = Mathf.Clamp(rotateT, 0, 1);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(startingRotationZ, startingRotationZ + 60, rotateT)));
        if (rotateT == 1) {
            rotating = false;
        }
    }

    public void PopOut() {
        if (!isOut) {
            startingPosition = transform.position;
            popDirection = 1;
            isOut = true;
        }
    }

    public void PopIn() {
        if (isOut) {
            popDirection = -1;
            isOut = false;
        }
    }

    public void Rotate() {
        if (!rotating) {
            startingRotationZ = transform.rotation.eulerAngles.z;
            rotating = true;
            rotateDirection = 1;
            rotateT = 0;
        }
    }
}
