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

	// Use this for initialization
	void Start () {
		// GameObject go = GameObject.Find("Thermo");
		// thermo = (Thermo) go.GetComponent(typeof(Thermo));
	}
	
	// Update is called once per frame
	void Update () {
		if (location == locationOptions.LeftHand) 
		{
			Thermo.LeftHand.Cold();
		}
		if (location == locationOptions.RightHand) 
		{
			Thermo.RightHand.Warm();
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
