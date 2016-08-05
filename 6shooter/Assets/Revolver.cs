using UnityEngine;
using System.Collections;

public class Revolver : MonoBehaviour {
    public EnemySpawner enemySpawner;
    public UIHandler uiHandler;
    public int score = 0;
    Barrel barrel;
    Hammer hammer;
    MuzzleFlash muzzleFlash;
    Body body;

    // Use this for initialization
    void Start() {
        barrel = GetComponentInChildren<Barrel>();
        hammer = GetComponentInChildren<Hammer>();
        muzzleFlash = GetComponentInChildren<MuzzleFlash>();
        body = GetComponentInChildren<Body>();
    }

    // Update is called once per frame
    void Update() {
        CheckDeath();

        if (Input.GetKey(KeyCode.RightArrow)) {
            barrel.PopOut();
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            barrel.PopIn();
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Fire();
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Cock();
        }

        if (Input.GetKey(KeyCode.W)) {
            MoveGun(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A)) {
            MoveGun(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S)) {
            MoveGun(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D)) {
            MoveGun(Vector3.right);
        }
    }

    protected void CheckDeath() {
        foreach (GameObject go in enemySpawner.enemyList) {
            if (go.transform.position.z < this.transform.position.z + 0.5f) {
                OnDeath();  
            }
        }
    }

    protected void OnDeath() {
        uiHandler.GameOver();
    }

    protected void MoveGun(Vector3 transl) {
        transl *= Time.deltaTime;
        transform.Translate(transl);
        TranslateStartingPositions(transl);
    }

    protected void TranslateStartingPositions(Vector3 transl) {
        barrel.startingPosition += transl;
        hammer.startingPosition += transl;
    }

    protected void Cock() {
        if (!hammer.cocked) {
            if (!barrel.isOut) {
                barrel.Rotate();
            }
            hammer.Cock();
        }
    }

    protected void Fire() {
        if (hammer.cocked && !barrel.isOut) {
            // check cylinder to be fired, check filled for fire / blank
            bool firedBullet = barrel.GetCurrentCylinder().Expel();
            hammer.Reset();
            if (firedBullet) {
                muzzleFlash.Flash();
                Camera.main.GetComponent<CameraBehavior>().Shake();

                Vector3 dir = (body.sightPoint - Camera.main.transform.position) * 100f;

                Debug.DrawRay(body.sightPoint, dir, Color.red, 100f);

                int layerMask = 1 << LayerMask.NameToLayer("Enemies");
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(body.sightPoint, dir, out hit, 100f, layerMask)) {
                    SlimeEnemy slime = hit.transform.gameObject.GetComponent<SlimeEnemy>();
                    slime.Damage(100);
                    score+=5;
                }

            }
        }
    }

    void OnDrawGizmos() {
    }
}
