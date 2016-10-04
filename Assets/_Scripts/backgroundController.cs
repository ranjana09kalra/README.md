using UnityEngine;
using System.Collections;

public class backgroundController : MonoBehaviour {

    //Private variable to control the scrooling speed of background
    [SerializeField]
    private int speed;
    private Transform _transform;

    //public properties for background
    public int SPEED
    {
        get { return this.speed; }
        set { this.speed = value; }

    }

    // Use this for initialization
    void Start() {
        this._transform = this.GetComponent<Transform>();
        this.speed = 1;
    }

    // Update is called once per frame
    void Update() {
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
        if (this._transform.position.x <= -400)
        {
            this._reset();
        }
    }

    // method to reset the background to original position
    private void _reset()
    {
        this._transform.position = new Vector2(400f, 0f);

    }
}
