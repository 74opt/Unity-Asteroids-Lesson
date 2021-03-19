using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public TextMesh scoreText;

    void Update() {
        scoreText.text = $"Score: {Player.pScore}";
    }
}
