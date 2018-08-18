using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D _rigidbody2D;
    float walkSpeed = 30f;
    Vector2 rot;
    public PlayerFunctions pFunctions;

    public GameObject pistolObject;

    void Start () {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Input.multiTouchEnabled = true;
	}
	
	void Update () {
        Movement();

    }
    public void Move(Vector2 vector , Quaternion rotation)
    {
        rot = vector ;
        if (rot != Vector2.zero)
            _rigidbody2D.AddForce(rot * walkSpeed, ForceMode2D.Force);

        gameObject.transform.rotation = rotation;
    }
    public void Rotate(Quaternion rotation)
    {
        pistolObject.transform.rotation = rotation;
    }
    
    void Movement()
    {
        
        if (Input.anyKey)
        {
            rot = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                rot = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rot = Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rot += Vector2.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rot += Vector2.left;
            }
            if(rot != Vector2.zero)
            _rigidbody2D.AddForce(rot * walkSpeed , ForceMode2D.Force);
        }
        else {
            //rigidbody2D.Sleep();
            //rigidbody2D.AddForce(-rot, ForceMode2D.Impulse);
        }
    }
    public void Shoot() {
        pFunctions.Fire();
    }
    void ShootInputs() {
        if (Input.GetButton("Fire1"))
        {
            pFunctions.Fire();
        }
        else if (Input.GetButton("Fire2")) {
            Debug.Log("Fire 2");
        }
    }
}