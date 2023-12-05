using System;
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
    public float stoppingdistance = 0.2f;
    public float attackRange = 1.5f;
    public bool attacks;

    public GameObject _gameObject;
    public float attackTimer;
    public float resetTimer;

    public bool _isSelected;
    public bool walk;
    public bool isMoving = false;

    public void setSelected(bool isSelected)
    {
        _isSelected = isSelected;
        walk = isSelected;
    }
    void Update()
    {
        if (_isSelected)
        {
            if (walk)
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
                startMoving();
            }
            else
            {
                destination = hit.point;
                return false;
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
            walk = false;
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
        }
    }

    void moveToEnemyPosition()
    {
        float distance = Vector3.Distance(transform.position, enemyTarget.transform.position);
        if (distance > stoppingdistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        else
        {
            walk = false;
            MoveToEnemy = false;
        }

        Vector3 direction = enemyTarget.transform.position - transform.position;
        direction.y = 0f; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        
        if (distance <= attackRange)
        {
            attacks = true;
        }
        else if (distance >= attackRange)
        {
            attacks = false;
        }
    }
    
    void attack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Vector3 spawnPosition = transform.position + transform.forward * 2f;
        
            Instantiate(_gameObject, spawnPosition, Quaternion.identity);
            attackTimer = resetTimer;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingdistance);
    }
}