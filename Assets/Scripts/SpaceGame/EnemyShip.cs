using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyShip : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;

    void Start()
    {
        weapon.Equip();
        StartCoroutine(FireTimer_CR());
    }

    IEnumerator FireTimer_CR()
    {
        while (true)
        { 
            float time = Random.Range(minFireRate,maxFireRate);
            yield return new WaitForSeconds(time);
            weapon.Use();
        }
    }

    void Update()
    {
        
    }
}
