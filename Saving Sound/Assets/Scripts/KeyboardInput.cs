using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class KeyboardInput : MonoBehaviour {
	public float velocityX;
    public float velocityY;
	private float forceX;
    private float forceY;
    private Vector3 vel;
	
	void Start () {
        forceX = 0f;
        forceY = 0f;
    }
    void Update(){
        forceY = 0;
        vel = GetComponent<Rigidbody2D>().velocity;
        forceX = -vel[0]*0.5f; // Detener al jugador cuando no hay input de izquierda o derecha
        if (Input.GetKey("right")){
            if (vel[0] < 0)
            {
                vel[0] = 0f;
            }
            forceX = velocityX;
        }
        if (Input.GetKey("left")){
            if (vel[0] > 0)
            {
                vel[0] = 0f;
            }
            forceX = -velocityX;
        }
        if (Input.GetKey("space") && GetComponent<StatsTracker>().jump == true)
        {
            forceY = velocityY;
            GetComponent<StatsTracker>().jump = false;
        }
        GetComponent<Rigidbody2D>().velocity = vel;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
    }
}

