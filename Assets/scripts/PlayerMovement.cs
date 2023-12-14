using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool movingToDestination = false;
    private Vector3 destination;
    public float speed = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleMouseClick();
        }
    }

    private void FixedUpdate()
    {
        if (movingToDestination)
        {
            MoveToDestination();
        }
    }

    void HandleMouseClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            destination = hit.point;
            movingToDestination = true;
        }
    }

    void MoveToDestination()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            movingToDestination = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
    }
}