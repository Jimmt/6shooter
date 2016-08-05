using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    public Text scoreText;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    public float borderMargin;
    public Revolver revolver;

	// Use this for initialization
	void Start () {
        mainMenuUI.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.transform.position = new Vector3(Screen.width - scoreText.preferredWidth / 2f - borderMargin, Screen.height - scoreText.preferredHeight / 2f - borderMargin, 0);
        scoreText.text = "SCORE: " + revolver.score;
    }

    public void GameOver() {
        gameOverUI.SetActive(true);
    }
}
