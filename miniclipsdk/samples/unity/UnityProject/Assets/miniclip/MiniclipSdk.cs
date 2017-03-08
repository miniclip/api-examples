using UnityEngine;
using System.Collections;

namespace mc {
	
	public delegate void Eventhandler(string eventName, object data);
	
public class MiniclipSdk : MonoBehaviour {

	static public MiniclipSdk instance;
	static private GameObject _gameObject;

	public AdsService ads;
	public AnalyticsService analytics;


	static public MiniclipSdk GetInstance()
	{
		if (instance == null){
			_gameObject = new GameObject();
			_gameObject.name = "mc-sdk-gameobject";
			_gameObject.AddComponent<MiniclipSdk>();
			instance = _gameObject.GetComponent<MiniclipSdk>();
			instance.Init ();
		}

		return instance;
	}

	private void Init()
	{
		Debug.Log ("Initializing MiniclipSDK");

		ads = new AdsService (this);

		Application.ExternalCall ("MC.unity.setup", _gameObject.name);
	}

	public void AdError ( string errorMsg )
	{
		//Debug.Log ("Got AdError");
		ads.OnAdError(errorMsg);
	}
	
	public void AdEvent( string eventName )
	{
		//Debug.Log ("Got AdEvent: " + eventName);
		ads.OnAdEvent (eventName);
	}


}

}
