using UnityEngine;
using System.Collections;

public class fishController : MonoBehaviour {

    //pub;ic instance varoables
    public GameController gameController;

    [Header("Sounds")]
    public AudioSource thunderSound;
    public AudioSource yaySound;

    //private instance variables
    private Transform _transform;
    public float speed;

	// Use this for initialization
	void Start () {
        this._transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
       // this._move();
	}

    // this move method is goint to move the player object across y axis with the mouse
    void FixedUpdate()
    {
        float moveVerticle = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f,moveVerticle,0.0f);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector3(GetComponent<Rigidbody2D>().position.x, Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -125, 234), 0.0f);
        //this._transform.position = new Vector2(100f,Mathf.Clamp( Input.mousePosition.y, 234f,125f));
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("octopus"))
        {
            //Debug.Log("Octopus Hit!");
            this.thunderSound.Play();
            this.gameController.LivesValue -= 1;
        }


        if (other.gameObject.CompareTag("fish2"))
        {
            // Debug.Log("fish2 Hit!");
            this.yaySound.Play();
            this.gameController.ScoreValue += 100;
        }
    }    

}
