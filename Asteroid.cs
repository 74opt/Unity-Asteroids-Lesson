using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public GameObject SpawnedAsteroid;

    float aVelocity, aX, aY;

    void Awake() {
        aX = Random.Range(0f, 1f);
        aY = Random.Range(0f, 1f);
        aVelocity = Random.Range(.6f, .8f);
        transform.rotation = new Quaternion(Random.Range(0, 180), Random.Range(0, 180), 0, 0);
    }

    void FixedUpdate() {
        transform.Translate(new Vector2(aX, aY) * aVelocity, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Physics2D.IgnoreLayerCollision(7, 8);
        // Note: In lesson, use Edit > Project Settings > Physics2D to show off collision ignoring

        if (collision.gameObject.CompareTag("Player Projectile")) {
            Player.pScore += 40 / gameObject.transform.localScale.x;
                if (gameObject.transform.localScale.x > .5f) {
                    transform.localScale /= 2;
                    Instantiate(SpawnedAsteroid, gameObject.transform.position, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), 0, 0));
                } else {
                    Destroy(gameObject);
                }
        }

        Teleport.TeleportToSide(collision, gameObject);
    }
}
