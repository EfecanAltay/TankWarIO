using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Potions;

public class HealthUpper : MonoBehaviour {

    HPotion potion = new HPotion();
	void Start () {
        potion.HP = 30;
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            bool b = col.gameObject.GetComponent<PlayerFunctions>().player.HealUP(potion.HP);
            if(b)
                Destroy(gameObject);
        }
    }
}
