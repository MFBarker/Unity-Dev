using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
    [SerializeField] private Action action;
    [SerializeField] private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        if (action != null)
        {
            action.onEnter += OnInteractStart;
            action.onStay += OnInteractActive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            inventory.Use();
        }


        if (Input.GetButtonDown("Fire2"))
        { 
            
        }
    }

    public override void OnInteractActive(GameObject gameObject)
    {
        
    }

    public override void OnInteractEnd(GameObject gameObject)
    {
        
    }

    public override void OnInteractStart(GameObject gameObject)
    {
        
    }
}
