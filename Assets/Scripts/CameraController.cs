using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Mario's Transform
    public Transform startLimit; // GameObject that indicates start of map
    public Transform startLimit2;
    public Transform endLimit1; // GameObject that indicates end of map
    public Transform endLimit2; // GameObject that indicates end of map
    private float offset_x; // initial x-offset between camera and Mario
    private float offset_y; // initial y-offset between camera and Mario
    private float startX; // smallest x-coordinate of the Camera
    private float startX2;
    private float endX1; // largest x-coordinate of the camera
    private float endX2; // largest x-coordinate of the camera
    private float endX;

    public Transform upperBound; // largest y-coordinate of the camera
    public Transform lowerBound; // smallest y-coordinate of the Camera
    private float upY;
    private float lowY;
    private float viewportHalfWidth;
    private float viewportHalfHeight;
    public float smoothTime = 0.05f;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 targetPosition;
    public float playerHeight = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // get coordinate of the bottomleft of the viewport
        // z doesn't matter since the camera is orthographic
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        viewportHalfWidth = Mathf.Abs(bottomLeft.x - this.transform.position.x);
        offset_x = this.transform.position.x - player.position.x;
        offset_y = this.transform.position.y - player.position.y;
        viewportHalfHeight = Mathf.Abs(upLeft.y - bottomLeft.y) / 2;
        //startX = this.transform.position.x;
        startX = startLimit.transform.position.x + viewportHalfWidth;
        startX2 = startLimit2.transform.position.x + viewportHalfWidth;
        endX1 = endLimit1.transform.position.x - viewportHalfWidth;
        endX2 = endLimit2.transform.position.x - viewportHalfWidth;
        lowY = lowerBound.transform.position.y;
        upY = upperBound.transform.position.y;
        endX = endX1;
    }

    // FixUpdate is called once per frame
    void FixedUpdate()
    {

        float desiredX = player.position.x + offset_x;
        float desiredY = player.position.y + offset_y;
        if (desiredY >= 31.0)
        {
            startX = startX2;
            endX = endX2;
        }
        float leftCheck = this.transform.position.x - viewportHalfWidth;
        float rightCheck = this.transform.position.x + viewportHalfWidth;
        float upCheck = this.transform.position.y + viewportHalfHeight;
        float downCheck = this.transform.position.y - viewportHalfHeight;

        if (desiredX < startX)
        {
            desiredX = startX;
        }
        else if (desiredX > endX)
        {
            desiredX = endX;
        }
        if (desiredY < lowY+viewportHalfHeight)
        {
            desiredY = lowY+viewportHalfHeight;
        }
        else if (desiredY > upY)
        {
            desiredY = upY;
        }

        if (desiredY >= upCheck - playerHeight || desiredY <= downCheck + viewportHalfHeight)
        {
            // transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
            Vector3 targetPosition = new Vector3(desiredX, desiredY, this.transform.position.z);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 targetPosition = new Vector3(desiredX, this.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
        }

        if (this.transform.position.x < startX)
        {
            this.transform.position = new Vector3(startX, this.transform.position.y, this.transform.position.z);
        }
        else if (this.transform.position.x > endX)
        {
            this.transform.position = new Vector3(endX, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.y > upY)
        {
            this.transform.position = new Vector3(this.transform.position.x, upY, this.transform.position.z);
        }
        else if (this.transform.position.y < lowY+viewportHalfHeight)
        {
            this.transform.position = new Vector3(this.transform.position.x, lowY+viewportHalfHeight, this.transform.position.z);
        }
    }
}
