using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mycam;

    public GameObject groundmarker;
    
    public LayerMask clickable;
    public LayerMask ground;
    void Start()
    {
        mycam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                     unitselections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                   unitselections.Instance.clickselect(hit.collider.gameObject); 
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    unitselections.Instance.DeselectAll();
                }
                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay((Input.mousePosition));

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundmarker.transform.position = hit.point;
                groundmarker.SetActive(false);
                groundmarker.SetActive(true);
            }
        }
        
        
    }
}
