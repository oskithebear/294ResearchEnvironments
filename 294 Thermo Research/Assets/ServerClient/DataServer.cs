using UnityEngine;
using System.Collections;
using ServerClient.TCP;

namespace ServerClient
{
	public class DataServer : MonoBehaviour
	{
		public delegate void GetData(string data);
		public event GetData getDataDelegate;
		public delegate void ClientConnected();
		public event ClientConnected clientConnectedDelegate;
		
		private LockFreeLinkPool<string> dataIn;
		
		// Use this for initialization
		void Start()
		{
			dataIn = new LockFreeLinkPool<string>();
			TransmitterSingleton.Instance.clientConnectedDelegate += OnClientConnected;
			TransmitterSingleton.Instance.startServer(new TransmitterSingleton.GetData(getData));
		}
		
		// Update is called once per frame
		void Update()
		{
			// Check Concurrent Pool for data
			SingleLinkNode<string> node = null;
			if (dataIn.Pop(out node))
			{
				string data = node.Item;
				getDataDelegate(data);
			}
		}

		// test
		void OnGUI()
		{
			//GUI.Label(new Rect(10, Screen.height - 30, 300, 20), "Smartphone Helper: " + TransmitterSingleton.Instance.connectionState);
		}
		
		void OnDestroy()
		{
			TransmitterSingleton.Instance.stopServer();
		}

		public void sendData(string data)
		{
			TransmitterSingleton.Instance.sendDataToClient(data);
		}
		
		void getData(string data)
		{
			// In order to get back to the main thread
			// (Unity cannot handle scene modifications on other threads),
			// we put the data in a concurrent pool
			SingleLinkNode<string> node = new SingleLinkNode<string>();
			node.Item = data;
			dataIn.Push(node);
			// Next part of the pipeline is DataServer.Update()
		}

		void OnClientConnected()
		{
			clientConnectedDelegate.Invoke();
		}
	}
}












