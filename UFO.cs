using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
    public GameObject uProjectile;
    public AudioSource audiosource;

    float uVelocity;
    Vector2 uMovement;

    void Awake() {
        List<int> direction = new List<int> { -1, 1 };

        uMovement = new Vector2(direction[Random.Range(0, 1)], 0);
        uVelocity = Random.Range(.2f, .4f);
    }

    void Update() {
        int chance = Random.Range(1, 30);

        if (chance == 1) {
            Instantiate(uProjectile, gameObject.transform);
            audiosource.Play();
        }
    }

    void FixedUpdate() {
        transform.Translate(uMovement * uVelocity, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Physics2D.IgnoreLayerCollision(7, 8);
        // Note: In lesson, use Edit > Project Settings > Physics2D to show off collision ignoring

        Teleport.TeleportToSide(collision, gameObject);

        if (collision.gameObject.CompareTag("Player Projectile")) {
            Player.pScore += 150;
            Destroy(gameObject);
        }
    }
}
