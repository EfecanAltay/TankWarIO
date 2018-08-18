using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Potions;

public class EnergyUpper : MonoBehaviour {


	void Start () {

	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            bool b = col.gameObject.GetComponent<PlayerFunctions>().player.TakeEnergy();
            if(b)
                Destroy(gameObject);
        }
    }
}
