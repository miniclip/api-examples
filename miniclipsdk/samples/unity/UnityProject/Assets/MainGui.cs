
using UnityEngine;
using System.Collections;

public class MainGui : MonoBehaviour
{
    private const float FontSizeMult = 0.05f;
    private string mStatusText = "Ready.";

	private bool videoAdBtn = true;
	private bool firstAdGroup = true;
	private bool isAdBlocked = false;

    void Start()
    {
		mc.MiniclipSdk sdk = mc.MiniclipSdk.GetInstance ();

		sdk.ads.events += OnEventHandler;

		sdk.ads.showAd("slot1");
		sdk.ads.showAd("leaderboard1");
		sdk.ads.checkAdBlocker();
    }

	void Update()
	{
	}

	void OnEventHandler( string eventName , object eventData )
	{
		switch(eventName){
		case mc.AdsService.AD_BLOCKED:
			mStatusText = " Turn off your ad blocker!";
			isAdBlocked = true;
			break;
		case mc.AdsService.COMPLETE:
			mStatusText = "Video Ad Complete";
			videoAdBtn = true;
			break;
		case mc.AdsService.STARTED:
			mStatusText = "Started Video Ad";
			break;
		case mc.AdsService.LOADED:
			mStatusText = "Loaded Video Ad";
			videoAdBtn = false;
			break;
		
		case mc.AdsService.ERROR:
			mStatusText = "Error in video:" + ((string)eventData);
			Debug.Log(mStatusText);
			break;

		}
	}

    void OnGUI()
    {
        GUI.skin.button.fontSize = (int)(FontSizeMult * Screen.height);
        GUI.skin.label.fontSize = (int)(FontSizeMult * Screen.height);

        GUI.Label(new Rect(20, 20, Screen.width, Screen.height * 0.25f),
                  mStatusText);

        Rect buttonRect = new Rect(0.25f * Screen.width, 0.10f * Screen.height,
                          0.5f * Screen.width, 0.20f * Screen.height);

		Rect buttonRect2 = new Rect(0.25f * Screen.width, buttonRect.yMax + 5,
			0.5f * Screen.width, 0.20f * Screen.height);

		Rect buttonRect3 = new Rect(0.25f * Screen.width, buttonRect2.yMax + 5,
			0.5f * Screen.width, 0.20f * Screen.height);

		Rect buttonRect4 = new Rect(0.25f * Screen.width, buttonRect3.yMax + 5,
			0.5f * Screen.width, 0.20f * Screen.height);

		Rect buttonRect5 = new Rect(0.25f * Screen.width, buttonRect4.yMax + 5,
			0.5f * Screen.width, 0.20f * Screen.height);
       

        string buttonLabel;
		if (firstAdGroup) {
			buttonLabel = "Show 2nd Ad Group";
		} else {
			buttonLabel = "Show 1st Ad Group";
		}
  
		if (GUI.Button (buttonRect, "Show Midroll Ad")) {
			mc.MiniclipSdk.GetInstance ().ads.requestVideoAd("midroll");
			mStatusText = "Requesting Video";
		}

		if (GUI.Button (buttonRect2, buttonLabel)) {
			firstAdGroup = !firstAdGroup;
			mc.MiniclipSdk sdk = mc.MiniclipSdk.GetInstance ();
			if (firstAdGroup) {
				sdk.ads.showAndRefresh("slot1");
				sdk.ads.showAndRefresh("leaderboard1");
				sdk.ads.hideAd("slot2");
				sdk.ads.hideAd("leaderboard2");
			} else {
				sdk.ads.showAndRefresh("slot2");
				sdk.ads.showAndRefresh("leaderboard2");
				sdk.ads.hideAd("slot1");
				sdk.ads.hideAd("leaderboard1");
			}
		}

		if (GUI.Button (buttonRect3, "Destroy slot1")) {
			mc.MiniclipSdk sdk = mc.MiniclipSdk.GetInstance ();
			sdk.ads.destroySlot("slot1");
		}

		if (GUI.Button (buttonRect4, "Send Init Event")) {
			mc.MiniclipSdk sdk = mc.MiniclipSdk.GetInstance ();
			sdk.analytics.sendInitEvent( new InitEvent(){ country = "PT", login_type = "guest", game_version = "v1.0"  });
		}

		if (GUI.Button (buttonRect5, "Send Match Event")) {
			mc.MiniclipSdk sdk = mc.MiniclipSdk.GetInstance ();
			sdk.analytics.sendMatchEvent( new MatchEvent(){ match_duration = 129, top_position = 5, final_position = 69  });
		}

    }
}

[System.Serializable]
public class InitEvent
{
    public string country;
    public string login_type;
    public string game_version;
}

[System.Serializable]
public class MatchEvent
{
    public int match_duration;
    public int top_position;
    public int final_position;
}
