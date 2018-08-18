using UnityEngine;

public class TouchController : MonoBehaviour {

    public PlayerController playerController;
    public LeftJoystick leftJoyStick;
    public RightJoystick rightJoyStick;


    void Start () {
        Input.multiTouchEnabled = true;
	}
	void Update () {
        MovingControllerUpdate();
        RotatingControllerUpdate();
    }
    public void MovingControllerUpdate() {

        Vector2 p = leftJoyStick.GetInputDirection();
        if ((p.x > -0.2f && p.x < 0.2) && (p.y > -0.2f && p.y < 0.2))
            return;

        float angle = Mathf.Atan(p.y / p.x) * Mathf.Rad2Deg;
        if (p.x < 0)
        {
            if (p.y < 0)
            {
                angle -= 180;
            }
            else
            {
                angle += 180;
            }
        }
        //playerController.Shoot();

        //Debug.Log("Angle : " + angle + " sw : " + Screen.width + " mw : " + Input.mousePosition.x);

        playerController.Move(leftJoyStick.GetInputDirection() , Quaternion.AngleAxis(angle, Vector3.forward));
    }
    public void RotatingControllerUpdate()
    {
        Vector2 p = rightJoyStick.GetInputDirection();
        if ((p.x > -0.2f && p.x < 0.2) && (p.y > -0.2f && p.y < 0.2))
            return;
        
        float angle = Mathf.Atan(p.y / p.x) * Mathf.Rad2Deg;
        if (p.x < 0)
        {
            if (p.y < 0)
            {
                angle -= 180;
            }
            else
            {
                angle += 180;
            }
        }
        //playerController.Shoot();

        //Debug.Log("Angle : " + angle + " sw : " + Screen.width + " mw : " + Input.mousePosition.x);
        playerController.Rotate(Quaternion.AngleAxis(angle, Vector3.forward));

    }
}
