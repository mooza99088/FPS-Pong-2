using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //key 1 
    public bool key1 { get; private set; }  

    // Start is called before the first frame update
    void Start()
    {
        key1 = false;
    }


    public void Pickupkey()
    {
        key1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
