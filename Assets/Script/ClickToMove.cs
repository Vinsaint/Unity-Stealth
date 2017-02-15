using UnityEngine;
using System.Collections;
using System;

public class ClickToMove : MonoBehaviour {
    
    [SerializeField]
    float standingSpeed= 10;

    Vector3 targetPosition;
    bool isMoving;

  
	void Start () {
        targetPosition = transform.position;
        isMoving = false;
	}
	
	void Update () {
        if (Input.GetMouseButton(1))
            SetTargetPosition();
       
        if (isMoving)
            MovePlayer();
	
	}

    private void MovePlayer()
    {

      //  transform.LookAt(targetPosition);
        Quaternion tranRot = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(tranRot, transform.rotation, 0.7f);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, standingSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
            isMoving = false;
    }

    private void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }
}
