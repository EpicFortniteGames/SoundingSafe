using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public bool jump;
    public int lives;
    public int score;
    public GameObject checkpoint;
    private Vector3 init_pos;
    public bool reached_checkpoint;
    void Start()
    {
        jump = true;
        lives = 3;
        score = 0;
        reached_checkpoint = false;
        init_pos = gameObject.transform.position;
    }
    void Update()
    {
        //print(score);
    }
    private void OnCollisionStay2D(Collision2D collision) //nPara objetos con que debe interactuar fisicamente
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            lives--;
            if (lives == 0)
            {
                Destroy(gameObject);
            }
            if (reached_checkpoint == true)
            {
                gameObject.transform.position = checkpoint.transform.position;
            }
            else
            {
                gameObject.transform.position = init_pos;
            }

        }
        else
        {
            var relativePosition = transform.InverseTransformPoint(collision.transform.position);
            //print(relativePosition.y);
            if (relativePosition.y < -4f) // Detectar que la colision con el collider por debajo
            {
                jump = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag != "DoubleJump")
        //{
        //    jump = false;
        //}
        jump = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) // Debe ser un Trigger para que no haya interaccion fisica con objetos de este estilo
    {
        if (collision.gameObject.tag == "Heart")
        {
            lives++;
        }
        else if(collision.gameObject.tag == "DoubleJump")
        {
            jump = true;
        }
        else if(collision.gameObject.tag == "Score")
        {
            score = score + 100;
        }
        else if(collision.gameObject.tag == "Checkpoint")
        {
            reached_checkpoint = true;
        }
        if (collision.gameObject.tag != "Checkpoint" && collision.gameObject.tag != "DoubleJump")
        {
            Destroy(collision.gameObject);
        }
    }
}

