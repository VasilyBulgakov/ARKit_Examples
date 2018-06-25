using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.iOS;


public static class HitUtility {

	
	/// <summary>
	/// checks hits in order of priority
	/// returns true on first valid hit and saves in out variables
	/// </summary>
	/// <param name="viewportPoint"></param>
	/// <param name="resultTypesPrioriy"></param>
	/// <param name="hitPos"></param>
	/// <param name="hitRotaion"></param>
	/// <returns></returns>
	public static bool getHitData(ARPoint viewportPoint, ARHitTestResultType[] resultTypesPrioriy, out Vector3 hitPos, out Quaternion hitRotaion)
	{						
		foreach(var resultType in resultTypesPrioriy)
		{
			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (viewportPoint, resultType);
			if (hitResults.Count > 0)
			{
				foreach (var hitResult in hitResults) 
				{	
					hitPos = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
					hitRotaion = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
					return true;
				}
			}		
		}		
		hitRotaion = Quaternion.identity;
		hitPos = Vector3.zero;
		return false;
	}


}

