using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public bool leftPlayer;
    public float speed;

    int leftUp, rightUp;

    Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftPlayer)  //control left paddle
        {
            if (Input.GetKey(KeyCode.W))
                leftUp = 1;
            if (Input.GetKey(KeyCode.S))
                leftUp = -1;

            rigidbody.AddForce(Vector2.up * leftUp * speed * Time.deltaTime);
            //new Vector2(0, leftUp * speed * Time.deltaTime)
        }
        else            //control right paddle
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rightUp = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                rightUp = -1;

            rigidbody.AddForce(Vector2.up * rightUp * speed * Time.deltaTime);
        }
    }
}
