using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testThermo : MonoBehaviour {

	public enum locationOptions
	{
		LeftHand,
		RightHand,
		LeftCollar,
		RightCollar
	}
	public locationOptions location;

	private string stepper = "HH";

	// Use this for initialization
	void Start () {
		// GameObject go = GameObject.Find("Thermo");
		// thermo = (Thermo) go.GetComponent(typeof(Thermo));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			stepper = "HH";
			Debug.Log(stepper);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			stepper = "HC";
			Debug.Log(stepper);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			stepper = "CC";
			Debug.Log(stepper);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			stepper = "CC";
			Debug.Log(stepper);
		}
		
		if (location == locationOptions.LeftHand) 
		{
			if(stepper == "HH" || stepper == "HC"){
				Thermo.LeftHand.Hot();
			}
			if(stepper == "CH" || stepper == "CC"){
				Thermo.LeftHand.Cold();
			}
		}
		if (location == locationOptions.RightHand) 
		{
			if(stepper == "HH" || stepper == "CH"){
				Thermo.RightHand.Hot();
			}
			if(stepper == "HC" || stepper == "CC"){
				Thermo.RightHand.Cold();
			}
		}
		if (location == locationOptions.LeftCollar) 
		{
			Thermo.LeftCollar.Warm();
		}
		if (location == locationOptions.RightCollar) 
		{
			Thermo.RightCollar.Neutral();
		}
	}
}
