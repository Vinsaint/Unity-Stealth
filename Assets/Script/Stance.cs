using UnityEngine;
using System.Collections;

public class Stance : MonoBehaviour {

    Animator anim;
    private bool down;


	// Use this for initialization
	void Start () {
        down = false;
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) down = !down;


        anim.SetBool("Down", down);
        
	}
}
