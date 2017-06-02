using UnityEngine;

namespace mc {
	
	public class AnalyticsService {

		private MiniclipSdk hub;

		public AnalyticsService( MiniclipSdk hub )
		{
			this.hub = hub;

			Init ();
		}

		private void Init()
		{
		}

		public void sendInitEvent( object opts )
		{
            string optsStr = JsonUtility.ToJson(opts);
			hub.CallMethod("analytics.sendInitEvent", optsStr);
		}

		public void sendEvent( string eventName, object opts, bool asynchronous = true )
		{
            string optsStr = JsonUtility.ToJson(opts);
			hub.CallMethod("analytics.sendEvent", eventName, optsStr, asynchronous);
		}

		public void sendMatchEvent( object opts, bool asynchronous = true )
		{
            string optsStr = JsonUtility.ToJson(opts);
			hub.CallMethod	("analytics.sendMatchEvent", optsStr, asynchronous);
		}

	}

}


