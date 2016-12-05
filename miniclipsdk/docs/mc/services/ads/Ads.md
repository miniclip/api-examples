# Methods

## createSlot (`slotid:String`, `unitId:String`, `dimensions:Array<Dynamic>`, `position:Null<SlotPlacementConfig>`, `?adOptions:Dynamic`):`String`
Builds an ad slot with a given ad unit and size and associates it with the ID of a div element on the page that will contain the ad.

## defineSlot (`tag:String`, `dimensions:Array<Dynamic>`, `containerId:String`, `params:Dynamic`):Void
Builds an ad slot with a given ad unit and size and associates it with the ID of a div element on the page that will contain the ad.

## hideAd (`containerId:String`):Void
## hideVideoAd ():Void
## isAdBlocked ():Bool
## refreshSlot (`?containerId:String`):Void
Fetches and displays new ads for specific slots on the page.

##requestVideoAd (`slotId:String`):Void
##showAd (`containerId:String`):Void
##showVideoAd ():Void
##updateSlot (`slotId:String, position:SlotPlacementConfig`):Void