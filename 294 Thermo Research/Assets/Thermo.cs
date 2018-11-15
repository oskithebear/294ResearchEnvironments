using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ServerClient;
using System.Threading;

public class Thermo : MonoBehaviour 
{

	public DataServer dataServer;

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

		public static void cool()
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

		public static void cool()
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

		public static void cool()
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

		public static void cool()
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
	void Update () 
	{
		string state = ConcatinateState();
		dataServer.sendData(state);
	}
}
