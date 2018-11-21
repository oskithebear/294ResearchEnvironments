using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


public class Thermo : MonoBehaviour 
{

	private string prevState = " ";

	public Thermo Instance { get; private set;}
	[System.Serializable]
	public static class LeftHand
	{
		private static string state = "neutral";
		public static string State
		{
			get
			{
				return state;
			}
		}

		public static void Hot()
		{
			state = "hot";
		}

		public static void Warm()
		{
			state = "warm";
		}

		public static void Neutral()
		{
			state = "neutral";
		}

		public static void Cool()
		{
			state = "cool";
		}

		public static void Cold()
		{
			state = "cold";
		}
	}

	[System.Serializable]
	public static class RightHand
	{
		private static string state = "neutral";
		public static string State
		{
			get
			{
				return state;
			}
		}

		public static void Hot()
		{
			state = "hot";
		}

		public static void Warm()
		{
			state = "warm";
		}

		public static void Neutral()
		{
			state = "neutral";
		}

		public static void Cool()
		{
			state = "cool";
		}

		public static void Cold()
		{
			state = "cold";
		}
	}

	[System.Serializable]
	public static class LeftCollar
	{
		private static string state = "neutral";
		public static string State
		{
			get
			{
				return state;
			}
		}

		public static void Hot()
		{
			state = "hot";
		}

		public static void Warm()
		{
			state = "warm";
		}

		public static void Neutral()
		{
			state = "neutral";
		}

		public static void Cool()
		{
			state = "cool";
		}

		public static void Cold()
		{
			state = "cold";
		}
	}

	[System.Serializable]
	public static class RightCollar
	{
		private static string state = "neutral";
		public static string State
		{
			get
			{
				return state;
			}
		}

		public static void Hot()
		{
			state = "hot";
		}

		public static void Warm()
		{
			state = "warm";
		}

		public static void Neutral()
		{
			state = "neutral";
		}

		public static void Cool()
		{
			state = "cool";
		}

		public static void Cold()
		{
			state = "cold";
		}
	}

	private string ConcatinateState()
	{
		return LeftHand.State + " " + RightHand.State + " " + LeftCollar.State + " " + RightCollar.State;
	}

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		string state = ConcatinateState();
		byte[] stateBytes = Encoding.ASCII.GetBytes(state);
		string IP = "192.168.7.2";
		int port= 13000;
		Socket client;
		IPEndPoint piZero;
		piZero = new IPEndPoint(IPAddress.Parse (IP), port);
		client = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		if (state != prevState) {
			Debug.Log("sending: " + state);
			client.SendTo (stateBytes, piZero);
			prevState = state;
		}
	}
}
