using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Asteroid;
    public GameObject Ship;
    GameObject Instance;
  
    Vector2 location;
    int side;
    IEnumerator coroutineAsteroid;
    IEnumerator coroutineShip;

    IEnumerator Spawn(GameObject entity, float time) {
        while (true) {
            yield return new WaitForSeconds(time);

            if (Limiter.canSpawn) {
                if (entity == Asteroid) {
                    side = Random.Range(1, 4);
                } else {
                    side = Random.Range(1, 2);
                }
                   
                switch (side) {
                    case 1: // Left
                        location = new Vector2(-90, Random.Range(-45, 45));
                        break;
                    case 2: // Right
                        location = new Vector2(90, Random.Range(-45, 45));
                        break;
                    case 3: // Up
                        location = new Vector2(Random.Range(-80, 80), 65);
                        break;
                    case 4: // Down
                        location = new Vector2(Random.Range(-80, 80), -65);
                        break;
                }

                Instance = Instantiate(entity, location, transform.rotation);

                if (entity == Asteroid) {
                    Animator AsteroidType = Instance.GetComponent<Animator>();

                    AsteroidType.SetInteger("AsteroidType", Random.Range(1, 4));
                }
            }
        }
    }

    void Start() {
        coroutineAsteroid = Spawn(Asteroid, 4f);
        coroutineShip = Spawn(Ship, 10f);

        StartCoroutine(coroutineAsteroid);
        StartCoroutine(coroutineShip);
    }
}
