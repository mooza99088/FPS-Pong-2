using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IInteraction
{

    [SerializeField] Inventory inventory;

    private bool locked;

    public void Activate()
    {
        if(inventory.key1 == true && locked == true)
        {
            Debug.Log("the lock opens");
            locked = false;
        }
        else if(inventory.key1 == true && locked == false)
        {
            Debug.Log("Already open!");
        }
        else
        {
            Debug.Log("you need a key");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
