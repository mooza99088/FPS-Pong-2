using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
   

    [SerializeField] private Vector3 ballVelocity;
    [SerializeField] public float ballSpeed = 10;


    private Rigidbody rbody;
  

    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<Rigidbody>(out rbody))
        {
            Debug.LogError("No rigidbody attached to the ball");

        }
        else
        {
            rbody.velocity = ballVelocity * ballSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = ballVelocity * ballSpeed;
    }

    public void SetVelocity(float dirx, float dirz, float spinVal)
    {
        float newX = ballVelocity.x * dirx;
        float newZ = ballVelocity.x * dirz;

        ballVelocity = new Vector3(newX, 0, newZ);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Paddle>(out Paddle pdl))
        {
            SetVelocity(-1, 1, 0);
        }
        else if(collision.gameObject.tag == "topbottom")
        {
            SetVelocity(-1, 1, 0);
        }
        else if(collision.gameObject.tag == "leftwall")
        {
            Debug.Log("Right Player has scored!");
            SetVelocity(-1, 1, 0);
        }
        else if (collision.gameObject.tag == "rightwall")
        {
            Debug.Log("Left Player has scored!");
            SetVelocity(-1, 1, 0);
        }

    }


}
