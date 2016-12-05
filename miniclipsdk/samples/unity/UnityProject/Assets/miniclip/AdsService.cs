using System;
using UnityEngine;

namespace mc {
	
	public delegate void Eventhandler(string eventName);

	public class AdsService {

		public const string COMPLETE = "ads.videoad.complete";
		public const string STARTED = "ads.videoad.started";
		public const string LOADED = "ads.videoad.ad_loaded";
		public const string AD_BLOCKED = "ads.adblocked";
		public const string NOT_AD_BLOCKED = "ads.not_adblocked";
		public const string PREROLL_COMPLETE = "ads.videoad.preroll_complete";
        public const string PREROLL_STARTED = "ads.videoad.preroll_started";

		private MiniclipSdk hub;

		public event Eventhandler events;

		public AdsService( MiniclipSdk hub )
		{
			this.hub = hub;

			Init ();
		}

		private void Init()
		{
		}

		public void OnAdEvent( string eventName )
		{
			events (eventName);
		}

		public void requestVideoAd( string slotId )
		{
			Application.ExternalCall ("MC.ads.requestVideoAd", slotId);
		}

		public void showAndRefresh( string slotId )
		{
			refreshSlot(slotId);
			showAd(slotId);
		}

		public void showAd( string slotId )
		{
			Application.ExternalCall("MC.ads.showAd", slotId);
		}

		public void hideAd( string slotId )
		{
			Application.ExternalCall("MC.ads.hideAd", slotId);
		}

		public void refreshSlot( string slotId )
		{
			Application.ExternalCall("MC.ads.refreshSlot", slotId);
		}

		public void checkAdBlocker()
		{
			Application.ExternalCall ("MC.unity.requestAdBlockerStatus");
		}

	}

}
