using UnityEngine;

public class PlayerFunctions : MonoBehaviour {

    public Player player = new Player();

    public GameObject Bullet;
    float fireTimer,fireTime = 1f ;
    bool isFireable = false;
    public Transform bulletStartTransform;
    float bulletSpeed = 200f;

    bool isPlayerHasEnergy = false;
    float playerEnergyTimer = 0f;

    void Start () {
        player.TakeEnergyCallBack += Player_TakeEnergyCallBack;
    }

    private void Player_TakeEnergyCallBack()
    {
        isPlayerHasEnergy = true;
        playerEnergyTimer = 5;
        fireTime = .2f;
    }

    void Update () {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else {
            isFireable = true;
        }
        if (isPlayerHasEnergy)
        {
            if(playerEnergyTimer > 0)
                playerEnergyTimer -= Time.deltaTime;
            else
            {
                playerEnergyTimer = 0;
                isPlayerHasEnergy = false;
                fireTime = 1f;
            }
            player.EnergyTimer = playerEnergyTimer;
        }
	}
    public void Fire() {
        if (isFireable)
        {
            GameObject go = Instantiate(Bullet, bulletStartTransform.position, bulletStartTransform.rotation);
            go.GetComponent<Rigidbody2D>().AddForce(go.transform.right * bulletSpeed * Time.deltaTime * 10,ForceMode2D.Impulse);
            fireTimer = fireTime;
            isFireable = false;
        }
    }
}
