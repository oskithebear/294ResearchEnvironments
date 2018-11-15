using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ServerClient;

public class AppLauncher : MonoBehaviour
{

	public DataServer connection;
	public bool launchOnStart = true;
	public float delayOnStart = 2.0f;
	public bool launchOnlyIfNotRunning = true;
	public string appProcessName = "";
	public string appPath = "";

	private bool isRunning = false;

	// Use this for initialization
	void Start()
	{
		connection.clientConnectedDelegate += OnClientConnected;
		if (launchOnStart)
		{
			StartCoroutine(WaitToLaunch());
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}



	public void launchApp()
	{
		if (launchOnlyIfNotRunning)
		{
			if (isRunning)
			{
				Debug.Log(appProcessName + " is already up and running.");
				return;
			}
		}

		Debug.Log("Starting App '" + appProcessName + "' from '" + Application.streamingAssetsPath + "/" + appPath + "'");
		System.Diagnostics.Process.Start(Application.streamingAssetsPath + "/" + appPath);
	}



	private IEnumerator WaitToLaunch()
	{
		yield return new WaitForSeconds(delayOnStart);
		launchApp();
	}

	private void OnClientConnected()
	{
		isRunning = true;
	}
}
















