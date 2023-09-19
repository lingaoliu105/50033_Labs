using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Mario's Transform
    public Transform startLimit; // GameObject that indicates start of map
    public Transform endLimit1; // GameObject that indicates end of map
    public Transform endLimit2; // GameObject that indicates end of map
    private float offset_x; // initial x-offset between camera and Mario
    private float offset_y; // initial y-offset between camera and Mario
    private float startX; // smallest x-coordinate of the Camera
    private float endX1; // largest x-coordinate of the camera
    private float endX2; // largest x-coordinate of the camera
    private float endX;

    public Transform upperBound; // largest y-coordinate of the camera
    public Transform lowerBound; // smallest y-coordinate of the Camera
    private float upY;
    private float lowY;
    private float viewportHalfWidth;
    private float viewportHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
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
        endX1 = endLimit1.transform.position.x - viewportHalfWidth;
        endX2 = endLimit2.transform.position.x - viewportHalfWidth;
        lowY = lowerBound.transform.position.y - viewportHalfHeight;
        upY = upperBound.transform.position.y - viewportHalfHeight;
        endX = endX1;
    }

    // Update is called once per frame
    void Update()
    {

        float desiredX = player.position.x + offset_x;
        float desiredY = player.position.y + offset_y;
        if (desiredY >= upY)
        {
            endX = endX2;
        }
        float leftCheck = this.transform.position.x - viewportHalfWidth;
        float rightCheck = this.transform.position.x + viewportHalfWidth;
        float upCheck = this.transform.position.y + viewportHalfHeight;
        float downCheck = this.transform.position.y - viewportHalfHeight;
        // if (leftCheck < startX)
        // {
        //     this.transform.position = new Vector3(startX + viewportHalfWidth, this.transform.position.y, this.transform.position.z);
        // }
        // if (rightCheck > endX)
        // {
        //     this.transform.position = new Vector3(endX - viewportHalfWidth, this.transform.position.y, this.transform.position.z);
        // }
        // if (upCheck > upY)
        // {
        //     this.transform.position = new Vector3(this.transform.position.x, upY - viewportHalfHeight, this.transform.position.z);
        // }
        // if (downCheck < lowY)
        // {
        //     this.transform.position = new Vector3(this.transform.position.x, lowY + viewportHalfHeight, this.transform.position.z);
        // }
        // check if desiredX is within startX and endX

        if (desiredX > startX && desiredX < endX && desiredY > lowY && desiredY < upY)
        {
            if (desiredY >= upCheck || desiredY <= downCheck)
            {
                this.transform.position = new Vector3(desiredX, desiredY, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(desiredX, this.transform.position.y, this.transform.position.z);
            }
        }
        else
        {
            if (desiredX <= startX)
            {
                this.transform.position = new Vector3(startX, this.transform.position.y, this.transform.position.z);
            }
            if (desiredX >= endX)
            {
                this.transform.position = new Vector3(endX, this.transform.position.y, this.transform.position.z);
            }
            if (desiredY >= upY)
            {
                this.transform.position = new Vector3(desiredX, upY, this.transform.position.z);
            }
            if (desiredY <= lowY)
            {
                this.transform.position = new Vector3(this.transform.position.x, lowY, this.transform.position.z);
            }
        }
    }
}
