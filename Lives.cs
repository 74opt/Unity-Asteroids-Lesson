using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
    public TextMesh livesText;

    void Update() {
        livesText.text = $"Lives: {Player.pLives}";
    }
}
