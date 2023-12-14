using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public static SlingShot Instance;
    private LineRenderer leftLineRender;
    private LineRenderer rightLineRender;

    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;

    private bool IsDrawing = false;
    private Transform birdTransform;

    private void Awake()
    {
        Instance = this;

        leftLineRender = transform.Find("LeftLineRender").GetComponent<LineRenderer>();
        rightLineRender = transform.Find("RightLineRender").GetComponent<LineRenderer>();

        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
    }
    // Start is called before the first frame update
    void Start()
    {


        HideLine();
    }


    // Update is called once per frame
    void Update()
    {
        if(IsDrawing)
        {
            Draw();
        }
        
    }
    public void StartDraw(Transform birdTransform)
    {
        IsDrawing = true;
        this.birdTransform = birdTransform;
        ShowLine();
        
    }
    public void EndDraw()
    {
        IsDrawing=false;
        HideLine();
    }
    public void Draw()
    {
        Vector3 birdPosition = birdTransform.position;

        birdPosition=(birdPosition - centerPoint.position).normalized*0.4f + birdPosition;
        
        leftLineRender.SetPosition(0, birdPosition);
        leftLineRender.SetPosition(1,leftPoint.position);

        rightLineRender.SetPosition(0, birdPosition);
        rightLineRender.SetPosition(1,rightPoint.position);
    }
    public Vector3 getCenterPosition()
    {
        return centerPoint.transform.position;
    }

    private void HideLine()
    {
        leftLineRender.enabled = false;
        rightLineRender.enabled = false;
    }

    private void ShowLine()
    {
        leftLineRender.enabled = true;
        rightLineRender.enabled = true;
    }
}
