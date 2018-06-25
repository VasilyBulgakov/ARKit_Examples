using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.iOS;

using UnityEngine;

public class MoveToClickedPos : MonoBehaviour {

		public Transform m_HitTransform;
		public GameObject m_SpawnPrefab;		
		public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer

		private ARHitTestResultType[] resultTypesPriority = {
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
                        ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    }; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && m_HitTransform != null)
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				ARPoint screenPoint = new ARPoint{
					x = screenPosition.x,
					y = screenPosition.y
				};
				Vector3 hitpos;
				Quaternion hitRot;
				if( HitUtility.getHitData(screenPoint,resultTypesPriority,out hitpos,out hitRot) )
				{
					if(m_HitTransform != null)
					{
						m_HitTransform.position = hitpos;
					}
				}
			}
		}
	}
}
