using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //public Rigidbody2D pBody;
    public GameObject pProjectile;
    public AudioSource audiosource;

    public Transform pProjectileSpawner;

    float pThrustAdd, pThrustMinus, pRotationSpeed, pVelocity, pVelocityLimit;
    public static float pScore;
    public static float pLives;

    void Start() {
        pScore = 0;
        pLives = 3;
        Application.targetFrameRate = 60;
    }

    void Awake() {
        pThrustAdd = .02f;
        pThrustMinus = .001f;
        pRotationSpeed = 3f;
        pVelocity = 0f;
        pVelocityLimit = .7f;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(pProjectile, pProjectileSpawner.position, transform.rotation);
            audiosource.Play();
        }
    }

    void FixedUpdate() {
        transform.Translate(Vector3.up * pVelocity, Space.Self);

        if (Input.GetKey(KeyCode.W) && pVelocity < pVelocityLimit) {
            pVelocity += pThrustAdd;
        } else if (pVelocity > 0){
            pVelocity -= pThrustMinus;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, 0, pRotationSpeed));
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3(0, 0, -pRotationSpeed));
        }
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(2);

        transform.position = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Teleport.TeleportToSide(collision, gameObject);

        if (!collision.gameObject.CompareTag("Teleporter")) {
            if (pLives == 1) {
                Destroy(gameObject);
            } else {
                pLives -= 1;
                transform.position = new Vector2(1000, 1000);

                IEnumerator coroutineRespawn = Respawn();
                StartCoroutine(coroutineRespawn);
            }
        } 
    }
}
