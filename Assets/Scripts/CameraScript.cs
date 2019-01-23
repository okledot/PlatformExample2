using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    [Header ("Объекты Unity")]
    public Transform player;

	
	void Update ()
    {
        Vector3 position = player.position;
        position.z = -10;
        transform.localPosition = position;
        
        /*
        if (playZone.x <= Camera.main.transform.position.x)
        {
            playZone.z = -10;
            transform.localPosition = playZone;
        }
        if (playZone.y <= Camera.main.transform.position.y)
        {
            playZone.z = -10;
            transform.localPosition = playZone;
        }
        */
	}
}
