using UnityEngine;
using System.Collections;

public class Camctrl : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    public Camera[] cameraList;
    private int currentCamera; 


	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
        if(cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCamera ++;
            if (currentCamera < cameraList.Length)
            {
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);

            }else
            {
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                currentCamera = 0;
                cameraList[currentCamera].gameObject.SetActive(true);
            }
        }
	
	}
}
