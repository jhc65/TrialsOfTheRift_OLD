using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
    // Private Vars
    private int i_redScore;
    private int i_blueScore;

    // Public vars
    public Text text_redScoreText;
    public Text text_blueScoreText;
    public GameObject go_canvas;

    //Singleton
    static GameController instance;

    // Use this for initialization
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != null && instance != this)
        {
            Debug.Log("Destroying non-primary GC.");
            Destroy(this);
        }

        Time.timeScale = 0;
    }

    void Start () {
	}
	
    // Update the Score
    public void Score(Constants.Color colorIn) {
        if (colorIn == Constants.Color.RED) {
            i_redScore++;
            text_redScoreText.text = i_redScore.ToString();
        }
        else if (colorIn == Constants.Color.BLUE) {
            i_blueScore++;
            text_blueScoreText.text = i_blueScore.ToString();
        }
    }

    public void SetConnectMessage(GameObject go_connectMessageIn) {
        //go_connectMessage = go_connectMessageIn;
    }

    public static GameController GetInstance() {
        return instance;
    }

    public void InitGame() {
        go_canvas.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
