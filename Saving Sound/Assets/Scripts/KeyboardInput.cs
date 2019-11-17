using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class KeyboardInput : MonoBehaviour {
	public float velocityX;
    public float velocityY;
	private float forceX;
    private float forceY;
    private Vector3 vel;
    private Animator running;
    private SpriteRenderer spriteRenderer;
	
	void Start () {
        forceX = 0f;
        forceY = 0f;
        running = GetComponent<Animator>();
        running.SetBool("is_running", false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update(){
        forceY = 0;
        vel = GetComponent<Rigidbody2D>().velocity;

        if (vel[0] != 0f)
        {
            running.SetBool("is_running", true);
            running.SetFloat("running_speed", vel[0]*0.075f);
        }
        else
        {
            running.SetBool("is_running", false);
        }


        forceX = -vel[0]*0.5f; // Detener al jugador cuando no hay input de izquierda o derecha
        if (Input.GetKey("right")){
            if (vel[0] < 0 && GetComponent<StatsTracker>().jump == true)
            {
                vel[0] = 0f;
            }
            forceX = velocityX;
            if (GetComponent<StatsTracker>().jump == false)
            {
                forceX = forceX/4f;
            }
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey("left")){
            if (vel[0] > 0 && GetComponent<StatsTracker>().jump == true)
            {
                vel[0] = 0f;
            }
            forceX = -velocityX;
            if (GetComponent<StatsTracker>().jump == false)
            {
                forceX = forceX / 4f;
            }
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey("space") && GetComponent<StatsTracker>().jump == true)
        {
            if(vel[1] < 4.8f){
                forceY = velocityY;
            }
            //print(vel);
            GetComponent<StatsTracker>().jump = false;
        }
        GetComponent<Rigidbody2D>().velocity = vel;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
    }
}

