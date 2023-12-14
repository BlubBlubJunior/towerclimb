using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 12f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float verticalSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Rotation with Q and E
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        }

        // Vertical Movement with middle mouse button
        float verticalMovement = Input.GetAxis("Mouse ScrollWheel") * 100f;
        Vector3 verticalDelta = Vector3.up * verticalMovement * verticalSpeed * Time.deltaTime;
        transform.Translate(verticalDelta, Space.World);
    }
}
