using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class playerBehever : MonoBehaviour
{
    public bool movingToDestination = false;
    private Vector3 destination;
    public float speed = 5f;
    

    public bool MoveToEnemy = false;
    public GameObject enemyTarget;
    public float Range = 1.5f;
    public bool attacks;

    public GameObject _gameObject;
    public float attackTimer;
    public float resetTimer;

    public bool _isSelected;
    public bool isMoving = false;
    
    [SerializeField] private AttackKindEnum state;

    /*private Dictionary<string, AttackKindEnum> ClassType = new Dictionary<string, AttackKindEnum>()
        {
            { "key1", AttackKindEnum.Melee },
            { "key2", AttackKindEnum.Magic }
        };*/
        
        //hello

    public void setSelected(bool isSelected)
    {
        _isSelected = isSelected;
    }
    void Update()
    {
        if (_isSelected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (HandleMouseClick())
                {
                    GoToPlay();
                }
                else
                {
                    movingToDestination = true;
                    isMoving = true;
                }
            }
        }
        
        if (attacks)
        {
            attack();
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (movingToDestination)
            {
                MoveToDestination();
            }
            else if (MoveToEnemy)
            {
                moveToEnemyPosition();
            }  
        }
    }

    bool HandleMouseClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                enemyTarget = hit.collider.gameObject;
                return true;
            }
            else
            {
                destination = hit.point;
                startMoving();
            }
        }

        return false;
    }

    void startMoving()
    {
        isMoving = true;
    }
    void MoveToDestination()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            isMoving = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
    }
    void GoToPlay()
    {
        if (enemyTarget != null)
        {
            destination = enemyTarget.transform.position;
            MoveToEnemy = true;
            movingToDestination = false;
            isMoving = true;
        }
    }

    void moveToEnemyPosition()
    {
        float distance = Vector3.Distance(transform.position, enemyTarget.transform.position);
        if (distance > Range)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            MoveToEnemy = false;
        }

        Vector3 direction = enemyTarget.transform.position - transform.position;
        direction.y = 0f; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        
        if (distance <= Range)
        {
            attacks = true;
        }
        else if (distance >= Range)
        {
            attacks = false;
        }
    }
    
    void attack()
    {
        
        switch (state)
        {
            case AttackKindEnum.Melee:
                MeleeAttack();
                break;

            case AttackKindEnum.Magic:
                MagicAttack();
                break;
            
            case AttackKindEnum.Archer:
                ArcherAttack();
                break;
        }
        
    }

    void MeleeAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Vector3 spawnPosition = transform.position + transform.forward * 2f;
        
            Instantiate(_gameObject, spawnPosition, Quaternion.identity);
            attackTimer = resetTimer;
        }
    }

    void MagicAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Vector3 spawnPosition = enemyTarget.transform.position;
        
            Instantiate(_gameObject, spawnPosition, Quaternion.identity);
            attackTimer = resetTimer;
        }
    }

    void ArcherAttack()
    {
        
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}