using UnityEngine;
using System.Collections;
using System;

public class ClickToMoveWithNavAgent : MonoBehaviour {
    
    Vector3 targetPosition;

    NavMeshAgent agent;

    Animator anim;
    private bool down;



    void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        targetPosition = transform.position;
        down = false;
        agent.speed = 5f;
    }
	
	void Update () {
        if (Input.GetMouseButton(1))
            SetTargetPosition();
            MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space)) down = !down;

        Boolean stance = anim.GetBool("Down");

        if (stance == true)
        {
            agent.speed = 2f;
        }else
        {
            agent.speed = 5f;
        }
        anim.SetBool("Down", down);
                
    }

    private void MovePlayer()
    {

        agent.SetDestination(targetPosition);

    }

    private void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);
    }
}
