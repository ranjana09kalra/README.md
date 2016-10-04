using UnityEngine;
// reference to the UI namespace
using UnityEngine.UI;
using System.Collections;
// reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
        

    [Header("Game Objects")]
    public GameObject fish1;
    public GameObject octopus;


    [Header("Labels")]
	// The actual GUI text objects
	public Text ScoreCounter;

	public Text LivesCounter;

    public Text GameOverLabel;

    public Text FinalScoreLabel;

    public Button RestartButton;

        //PRIVATE INSTANCE VARIABLES
	private int  _scoreValue;
	private int  _livesValue;
    private AudioSource _endGameSound;

    // PUBLIC INSSTANCE VARIABLES
   // public int fish2Number = 3;
    public GameObject fish2;


        // PIBLICE PROPERTIES
public int LivesValue
    {
        get {
            return this._livesValue;
        }

        
        set {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
                this.LivesCounter.text = "Lives" + this._livesValue;
            }

    }

    public int ScoreValue {
        get {
            return this._scoreValue;
        }
        set {
            this._scoreValue = value;
            this.ScoreCounter.text = "Score: " + this._scoreValue;
        }
    }

    void Start()
    {
        this.LivesValue = 5;    
        this.ScoreValue = 0;

        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
        this._endGameSound = this.GetComponent<AudioSource>();
        //for (int fish2Count=0; fish2Count< this.fish2Number; fish2Count++ )
        //{
        //    Instantiate(this.fish2);
        //}
    }

    private void _endGame()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.ScoreCounter.gameObject.SetActive(false);
        this.LivesCounter.gameObject.SetActive(false);
        this.fish1.SetActive(false);
        this.octopus.SetActive(false);
        this._endGameSound.Play();
    }



    //Public Methods

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Game");
    }
    
}
