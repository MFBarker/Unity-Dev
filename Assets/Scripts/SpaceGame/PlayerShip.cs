using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("Fire1")) 
        {
            //inventory.Use();
        }
        if (Input.GetButtonUp("Fire2"))
        { 
            
        }
    }
}
