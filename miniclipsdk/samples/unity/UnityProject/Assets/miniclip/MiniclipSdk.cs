using UnityEngine;
using System.Collections;

namespace mc {
	
public class MiniclipSdk : MonoBehaviour {

	static public MiniclipSdk instance;
	static private GameObject _gameObject;

	public AdsService ads;


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

	public void AdEvent( string eventName )
	{
		Debug.Log ("Got AdEvent: " + eventName);
		ads.OnAdEvent (eventName);
	}


}

}
