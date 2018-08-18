using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    GameObject playerTarget;
    Camera thisCamera;
    Vector3 mousePos;
    Vector3 playerRotationVector;

    float angle;
    void Start () {
        playerTarget = GameObject.Find("Player");
        thisCamera = GetComponent<Camera>();
      
    }

    void Update () {
        FollowPlayer();
        //MouseTarget();
    }
    void FollowPlayer()
    {
        gameObject.transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, -10);
    }
    void MouseTarget()
    {
        mousePos = thisCamera.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("pos :" + (mousePos - playerTarget.transform.position));
        playerRotationVector = mousePos - playerTarget.transform.position;
        Debug.DrawRay(playerTarget.transform.position, playerRotationVector);
        angle = Mathf.Atan(playerRotationVector.y / playerRotationVector.x) * Mathf.Rad2Deg;
        if (Input.mousePosition.x < Screen.width / 2)
        {
            if (Input.mousePosition.y < Screen.height / 2)
            {
                angle -= 180;
            }else
            {
                angle += 180;
            }
        }

        //Debug.Log("Angle : " + angle + " sw : " + Screen.width + " mw : " + Input.mousePosition.x);
        playerTarget.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}