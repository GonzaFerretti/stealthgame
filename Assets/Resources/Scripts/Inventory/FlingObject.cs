﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlingObject : Model
{
    public ActionWrapper[] collisionAction;
    public Rigidbody rb;
    Collider col;
    
    //MeshFilter myMesh;

    //public void SetAttributes(Item item)
    //{
    //    myMesh.mesh = item.mesh;
    //}
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject)
        {
            for (int i = 0; i < collisionAction.Length; i++)
            {
                if (collisionAction[i].action == null) collisionAction[i].SetAction();
                collisionAction[i].action.Do(this);
            }
            gameObject.SetActive(false);
        }
    }
}