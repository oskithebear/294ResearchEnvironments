using UnityEngine;
using System.Collections;
using ServerClient.TCP;

namespace ServerClient
{
	public class DataClient : MonoBehaviour
	{
		public delegate void GetData(string data);
		public event GetData getDataDelegate;

		private LockFreeLinkPool<string> dataIn;

		// Use this for initialization
		void Start()
		{
			dataIn = new LockFreeLinkPool<string>();
			TransmitterSingleton.Instance.clientStartListening(new TransmitterSingleton.GetData(clientGetData));
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

		void OnDestroy()
		{
			TransmitterSingleton.Instance.clientStopListening();
		}

		public void sendData(string data)
		{
			TransmitterSingleton.Instance.sendDataToServer(data);
		}

		void clientGetData(string data)
		{
			// In order to get back to the main thread
			// (Unity cannot handle scene modifications on other threads),
			// we put the data in a concurrent pool
			SingleLinkNode<string> node = new SingleLinkNode<string>();
			node.Item = data;
			dataIn.Push(node);
			// Next part of the pipeline is DataHandler.Update()
		}
	}
}












