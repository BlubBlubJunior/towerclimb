using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    public Transform target;
    
    public float range;

    public float attacktimer = 2f;

    
    public GameObject attackprefab;
    private void Update()
    {
        transform.LookAt(target);
        attacktimer -= Time.deltaTime;
       
        Collider[] cols = Physics.OverlapSphere((Vector3)transform.position, range);
        if(cols.Length > 0)
        {
            target = cols[0].gameObject.transform;
        }   
        foreach (Collider col in cols)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                attackplayer(); 
            }
        }  
    }

    

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void attackplayer()
    {
        if (attacktimer < 0 )
        {
            Instantiate(attackprefab,transform.position + (transform.forward * 1.5f), transform.rotation);
            attacktimer = 2f;
        }
        
    }
}
