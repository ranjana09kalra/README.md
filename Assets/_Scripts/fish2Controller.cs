using UnityEngine;
using System.Collections;

public class fish2Controller : MonoBehaviour {

    private int speed;
    private Transform _transform;



    //public properties for background
    public int SPEED
    {
        get { return this.speed; }
        set { this.speed = value; }

    }

    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>();

        this._reset();

    }

    // Update is called once per frame
    void Update()
    {
        this._move();
        this._checkBounds();
    }

    // Method to move the object towards left by speed pixels per frame
    private void _move()
    {
        Vector2 newPosition = this._transform.position;
        newPosition.x -= this.speed;
        this._transform.position = newPosition;
    }

    // method to check the boundary of the background

    private void _checkBounds()
    {
        if (this._transform.position.x <= -450)
        {
            this._reset();
        }
    }

    // method to reset the background to original position
    private void _reset()
    {
        this.speed = Random.Range(5, 10);
        this._transform.position = new Vector2(250f, Random.Range(-150, 250));

    }
}
