using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            print("CHOQUE");
            if (gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>())
            {
                
                gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
            }
            


        }


    }


}