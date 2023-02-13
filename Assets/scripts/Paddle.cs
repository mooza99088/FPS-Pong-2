using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] bool isLeftPaddle;

    private Rigidbody rbody;



    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<Rigidbody>(out rbody))
        {
            Debug.LogError("There is no rigidbody attached to this paddle!");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftPaddle)
        {
            if(Input.GetAxisRaw("VerticalLeft") > 0)
            {
                rbody.AddForce(0, 0, speed);
            }
            else if(Input.GetAxisRaw("VerticalLeft") < 0)
            {
                rbody.AddForce(0, 0, -speed);
            }
            else
            {
                rbody.velocity = Vector3.zero;  
            }
        }
        else
        { 
                if (Input.GetAxisRaw("VerticalRight") > 0)
                {
                    rbody.AddForce(0, 0, speed);
                }
                else if (Input.GetAxisRaw("VerticalRight") < 0)
                {

                    rbody.AddForce(0, 0, -speed);
                }
                else
                {
                    rbody.velocity = Vector3.zero;
                }
        }

        
    }
}
