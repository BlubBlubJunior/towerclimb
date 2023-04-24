using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDrag : MonoBehaviour
{
    private Camera mycam;

    [SerializeField] private RectTransform boxvisual;

    private Rect selectionbox;

    private Vector2 startposition;
    private Vector2 endposition;

    private void Start()
    {
        mycam = Camera.main;
        startposition = Vector2.zero;
        endposition = Vector2.zero;
        drawvisual();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startposition = Input.mousePosition;
            selectionbox = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            endposition = Input.mousePosition;
            drawvisual();
            drawselection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectUnits();
            startposition = Vector2.zero;
            endposition = Vector2.zero;
            drawvisual();
        }
    }

    void drawvisual()
    {
        Vector2 boxstart = startposition;
        Vector2 boxend = endposition;

        Vector2 boxcenter = (boxstart + boxend) / 2;
        boxvisual.position = boxcenter;

        Vector2 boxsize = new Vector2(Mathf.Abs(boxstart.x - boxend.x), Mathf.Abs(boxstart.y - boxend.y));

        boxvisual.sizeDelta = boxsize;
    }

    void drawselection()
    {
        if (Input.mousePosition.x < startposition.x)
        {
            selectionbox.xMin = Input.mousePosition.x;
            selectionbox.xMax = startposition.x;
        }
        else
        {
            selectionbox.xMin = startposition.x;
            selectionbox.xMax = Input.mousePosition.x; 
        }

        if (Input.mousePosition.y < startposition.y)
        {
            selectionbox.yMin = Input.mousePosition.y;
            selectionbox.yMax = startposition.y;
        }

        else
        {
            selectionbox.yMin = startposition.y;
            selectionbox.yMax = Input.mousePosition.y;
        }
    }

    void selectUnits()
    {
        foreach (var unit in unitselections.Instance.unitlist)
        {
            if (selectionbox.Contains(mycam.WorldToScreenPoint(unit.transform.position)))
            {
                unitselections.Instance.DragSelect(unit);
            }
        }
    }
}
