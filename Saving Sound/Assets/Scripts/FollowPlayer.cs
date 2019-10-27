using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform whoToFollow;
    private float posX;
    private float posY;
    public int adjust = 1;

    // Use this for initialization
    void Start()
    {

        MoveCamera();

    }

    // Update is called once per frame
    void Update()
    {

        MoveCamera();

    }

    void MoveCamera()
    {
        if (whoToFollow && transform)
        {
            posX = whoToFollow.transform.position.x;
            posY = transform.position.y;
            transform.position = new Vector3(posX + adjust, posY, -3);
        }

    }
}
