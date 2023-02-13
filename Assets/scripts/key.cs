using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour, IInteraction
{

    [SerializeField] Inventory inventory;

    public void Activate()
    {
        inventory.Pickupkey();
        Debug.Log("you picked up a key");
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
