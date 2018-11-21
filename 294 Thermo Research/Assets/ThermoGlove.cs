using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermoGlove : MonoBehaviour {

	public enum locationOptions
	{
		LeftHand,
		RightHand
	}
	public locationOptions location;

	void OnTriggerEnter(Collider other){
		Debug.Log("Collision");
		if (other.gameObject.tag == "campFire"){
			if (location == locationOptions.LeftHand){
				Thermo.LeftHand.Hot();
			}else{
				Thermo.RightHand.Hot();
			}
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log("exit collision");
		if (location == locationOptions.LeftHand){
			Thermo.LeftHand.Cool();
		}else{
			Thermo.RightHand.Cool();
		}
	}

	// Use this for initialization
	void Start () {
		if (location == locationOptions.LeftHand){
				Thermo.LeftHand.Cold();
			}else{
				Thermo.RightHand.Cold();
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
