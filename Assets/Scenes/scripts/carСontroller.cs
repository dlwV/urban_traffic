using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class carController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f, rotateSpeed = 35f;
    private int carCount = 0;
    private int oncomingTraffic = 0;

    [NonSerialized] public Vector3 FinalPosition;
    [NonSerialized] public bool turn_left = true;
    [NonSerialized] public bool trafficLightGreen = true;
    [NonSerialized] public bool carAhead = false;

    private enum Direction
    {
        Front, Back, Left, Right
    }
    private Direction CarDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        float rotation = transform.eulerAngles.y;
        switch (rotation)
        {
            case 0f:
                CarDirection = Direction.Front;
                break;
            case 90f:
                CarDirection = Direction.Left;
                break;
            case 180f:
                CarDirection = Direction.Back;
                break;
            case 270f:
                CarDirection = Direction.Right;
                break;
        }

    }

    void Update()
    {
        if (FinalPosition.x == 0)
        {
            if (trafficLightGreen)
            {
                speed = 10f;
            }
            else
            {
                speed = 0f;
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            if (carCount == 0)
            {
                speed = 10f;
            }
            else
            {
                speed = 0f;
            }
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, speed * Time.deltaTime);
            Vector3 lookAtPos = FinalPosition - transform.position;
            lookAtPos.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookAtPos), Time.deltaTime * rotateSpeed * speed);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("turn_left"))
        {
            if (oncomingTraffic < 2)
            {
                carCount = other.GetComponent<turnLeft>().carCount;
            }
        }
        if (other.CompareTag("car"))
        {
            Vector3 relativePosition = other.transform.position - transform.position;
            if ((relativePosition.x > 0 && CarDirection == Direction.Left) || (relativePosition.x < 0 && CarDirection == Direction.Right) || (relativePosition.z > 0 && CarDirection == Direction.Front) || (relativePosition.z < 0 && CarDirection == Direction.Back))
            {
                carAhead = true;
                trafficLightGreen = false;
            }
            else
            {
                carAhead = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("turn_left"))
        {
            oncomingTraffic++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("car"))
        {
            carAhead = false;
            trafficLightGreen = true;
        }
    }

}
