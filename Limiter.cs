using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour {
    int objects;
    public static bool canSpawn;

    void Update() {
        objects = GameObject.FindObjectsOfType(typeof(MonoBehaviour)).Length;
        if (objects > 20) {
            canSpawn = false;
        } else {
            canSpawn = true;
        }
    }
}
