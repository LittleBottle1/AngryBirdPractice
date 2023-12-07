using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public enum BirdState
    {
        Waiting,
        BeforeShoot,
        AfterShoot
    }
    public BirdState state = BirdState.BeforeShoot;

    public float flySpeed = 5;
    private Rigidbody2D rgd;

    //等待 发射前 发射后
    private bool isMouseDown = false;
    public float maxDistance = 2.3f;
    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        rgd.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        if(state ==BirdState.BeforeShoot)
        {
            isMouseDown = true;
            SlingShot.Instance.StartDraw(transform);
        }
    }
    private void OnMouseUp()
    {
        if(state == BirdState.BeforeShoot)
        {
            isMouseDown = false;
            SlingShot.Instance.EndDraw();
            Fly();
        }
    }
    private void MoveControl()
    {
        if(isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }
    private Vector3 GetMousePosition()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 centerPosition = SlingShot.Instance.getCenterPosition();
        mp.z = 0;

        float distance = (mp - centerPosition).magnitude;

        if(distance > maxDistance)
        {
            mp = (mp - centerPosition).normalized *maxDistance +centerPosition;
        }

        return mp;
    }
    private void Fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = (SlingShot.Instance.getCenterPosition() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShoot;
    }
}
