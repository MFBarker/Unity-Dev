using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private Inventory inventory;
    [SerializeField] private IntVariable score;
    [SerializeField] private FloatVariable health;

    [SerializeField] protected GameObject hitPrefab;
    [SerializeField] protected GameObject destroyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        scoreEvent.Subscribe(AddPoints);
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
            //add new weapon
        }
    }

    private void AddPoints(int points)
    {
        score.value += points;
        Debug.Log(score.value);
    }

    public void ApplyDamage(float damage)
    {
        health.value -= damage;
        if (health <= 0)
        {
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        else
        {
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
