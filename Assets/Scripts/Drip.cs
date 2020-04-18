﻿using System.Collections;
using UnityEngine;

public class Drip : MonoBehaviour
{
    public Animator animator_;

    public Vector2 maxMovement_;
    public float minimumDistance_;
    public float moveFrequency_;
    public float moveSpeed_;
    public float stopRange_;

    private Vector3 destination_;

    private void Start()
    {
        StartCoroutine(PickNewDestination());
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, destination_) > stopRange_)
        {
            Move();
            animator_.SetBool("isWalking", true);
        }
        else
        {
            animator_.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        transform.position = new Vector3(
            Mathf.SmoothStep(transform.position.x, destination_.x, moveSpeed_ * Time.deltaTime),
            Mathf.SmoothStep(transform.position.y, destination_.y, moveSpeed_ * Time.deltaTime),
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        if(destination_ != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(destination_, 0.1f);
        }
    }

    private IEnumerator PickNewDestination()
    {
        Vector3 move;
        do
        {
            move = new Vector2(
                Random.Range(-maxMovement_.x, maxMovement_.x),
                Random.Range(-maxMovement_.y, maxMovement_.y));
        }
        while(move.magnitude < minimumDistance_);

        destination_ = transform.position + move;

        yield return new WaitForSeconds(moveFrequency_);
        StartCoroutine(PickNewDestination());
    }
}
