﻿using System;
using UnityEngine;

namespace mc {

	public class AdsService {

		public const string COMPLETE = "ads.videoad.complete";
		public const string STARTED = "ads.videoad.started";
		public const string LOADED = "ads.videoad.ad_loaded";
		public const string AD_BLOCKED = "ads.adblocked";
		public const string NOT_AD_BLOCKED = "ads.not_adblocked";
		public const string PREROLL_COMPLETE = "ads.videoad.preroll_complete";
        public const string PREROLL_STARTED = "ads.videoad.preroll_started";
		public const string ERROR = "ads.videoad.error";

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

		public void OnAdError( string errorMsg )
		{
			events ( ERROR, errorMsg);
		}

		public void OnAdEvent( string eventName )
		{
			events (eventName, null);
		}

		public void requestVideoAd( string slotId )
		{
			hub.CallMethod("ads.requestVideoAd", slotId);
		}

		public void showAndRefresh( string slotId )
		{
			refreshSlot(slotId, true);
		}

		public void showAd( string slotId )
		{
			hub.CallMethod("ads.showAd", slotId);
		}

		public void hideAd( string slotId )
		{
			hub.CallMethod("ads.hideAd", slotId);
		}

		public void refreshSlot( string slotId, bool showOnLoad = false )
		{
			hub.CallMethod("ads.refreshSlot", slotId, showOnLoad);
		}

		public void destroySlot( string slotId )
		{
			hub.CallMethod("ads.destroySlot", slotId);
		}

		public void checkAdBlocker()
		{
			hub.CallMethod("unity.requestAdBlockerStatus");
		}

	}

}
