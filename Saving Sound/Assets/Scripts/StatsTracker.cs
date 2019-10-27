using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public bool jump;
    public int lives;
    void Start()
    {
        jump = true;
    }
    void Update()
    {
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var relativePosition = transform.InverseTransformPoint(collision.transform.position);
        if(relativePosition.y < 0) // Detectar que la colision con el collider por debajo
        {
            jump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jump = false;
    }
}
