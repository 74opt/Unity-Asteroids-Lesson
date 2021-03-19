using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    Transform PlayerPosition;
    Vector2 LocationShot;

    float ProjectileVelocity, ProjectileTime;

    void Awake() {
        try {
            PlayerPosition = GameObject.Find("Asteroids_Player").GetComponent<Transform>();
        } catch {}

        ProjectileVelocity = 1.5f;
        ProjectileTime = 2f;

        try {
            LocationShot = PlayerPosition.position;
        } catch {}
    }

    void Update() {
        if (ProjectileTime > 0) {
            ProjectileTime -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if (gameObject.CompareTag("Player Projectile")) {
            transform.Translate(Vector3.up * ProjectileVelocity, Space.Self);
        } else {
            if (PlayerPosition != null) {
                transform.position = Vector2.MoveTowards(transform.position, LocationShot * 20, ProjectileVelocity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //if (gameObject.CompareTag("Danger")) {
        //    Physics2D.IgnoreLayerCollision(7, 8);  
        //}
        // Note: In lesson, use Edit > Project Settings > Physics2D to show off collision ignoring

        Teleport.TeleportToSide(collision, gameObject);

        if (!collision.gameObject.CompareTag("Teleporter")) {
            Destroy(gameObject);
        }
    }
}
