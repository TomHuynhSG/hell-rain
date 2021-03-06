/* Script to control the attacking behaviour of the player

 * Authors: Jason Lee, Erlangga Satria Gama, Minh Thong, Brian Kang */


using UnityEngine;
using System.Collections;

public class ChangeCameraByBoundary : MonoBehaviour {
	private Vector3 defaultPosition;
	private Vector3 defaultRotation;


	void OnTriggerEnter(Collider other) {
		if (other.tag == "MainCamera") {
			defaultPosition= other.transform.position;
			defaultRotation= other.transform.eulerAngles;
			other.transform.position=new Vector3(defaultPosition.x,defaultPosition.y,0f);
			CameraFollow cameraFollowScript=other.GetComponent <CameraFollow> ();
			cameraFollowScript.offset= other.transform.position - cameraFollowScript.target.position;
			if(this.tag=="SouthBoundary"){
				other.transform.eulerAngles= new Vector3(defaultRotation.x,180f,defaultRotation.z);
			} else {
				other.transform.eulerAngles= new Vector3(defaultRotation.x,0f,defaultRotation.z);
			}

			PlayerMovement playerMovementScript=cameraFollowScript.target.GetComponent <PlayerMovement> ();
			if(this.tag=="SouthBoundary"){
				playerMovementScript.reverseDirection=true;
			} else {
				playerMovementScript.reverseDirection=false;
			}

		}

	}
}
