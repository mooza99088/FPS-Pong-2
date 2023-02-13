using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    //float mouse sensitivity
    [SerializeField] private float sens;
    
    //vertical clamp
    [SerializeField] private float clamp;

    //reference to the camera 
    [SerializeField] private GameObject cam;

    //reference to the player object
    [SerializeField] private GameObject player;

    //float for X rotation
    private float rotX;
    //float for Y rotation
    private float rotY;


    // Start is called before the first frame update
    void Start()
    {
        //assign the x and y rotation of the camera to a vector 3 
        Vector3 rot = transform.localRotation.eulerAngles;
       

        //set rot X and rot Y to be equal to rotation of camera 
        rotX = rot.x;
        rotY = rot.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }


        //get the mouse x and mouse y movement and assign to floats 
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        //modify rotX / Y  the mouse x and y, multiplied by the sensitiveity and time.deltaTime
        rotX += mouseX * sens * Time.deltaTime;
        rotY += mouseY * sens * Time.deltaTime;

        //apply clamping on the X axis
        rotX = Mathf.Clamp(rotX, -clamp, clamp);

        //create a local quaternion with the rotX / rotY values
        Quaternion localRot = Quaternion.Euler(-rotX, 0f, 0f);
        Quaternion bodyRot = Quaternion.Euler(0f, rotY, 0f);

        //update the transform.rotation
        transform.rotation = localRot;
        player.transform.rotation = bodyRot;
        
    }

    private void interact()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if(hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter))
            {
                inter.Activate();
            }
        }
    }
}

public interface IInteraction
{

    public void Activate();
}
