using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public static void TeleportToSide(Collision2D collision, GameObject go) {
        switch (collision.gameObject.name) {
            case "TeleportUp":
                go.transform.position = new Vector3(0, -55, 0);
                break;
            case "TeleportDown":
                go.transform.position = new Vector3(0, 55, 0);
                break;
            case "TeleportLeft":
                go.transform.position = new Vector3(87.5f, 0, 0);
                break;
            case "TeleportRight":
                go.transform.position = new Vector3(-87.5f, 0, 0);
                break;
        }
    }
}
