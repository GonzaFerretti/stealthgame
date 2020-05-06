﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelPlayable : ModelHumanoid
{
    float _sneakSpeed;    
    public Inventory inv;
    public CharacterAttributes myAttributes;
    public ControllerWrapper usualController;
    public ControllerWrapper redirectController;
    public ControllerWrapper hideController;
    public ControllerWrapper flingController;
    public FlingSpotLight flingSpotlight;

    protected override void Start()
    {
        DontDestroyOnLoad(this);
        controller = usualController;
        base.Start();
        SetAttributes(myAttributes);
        flingController.SetController();
        flingController.myController.AssignModel(this);

        for (int i = 0; i < availableActions.Count; i++)
        {
            availableActions[i].SetAction();
        }

        if (controller is PlayerController)
        {
            (controller as PlayerController).StartFunction();
        }

        inv = inv.cloneInvTemplate();
        inv.initializeInventory(this);
    }

    void SetAttributes(CharacterAttributes attributes)
    {
        standardSpeed = attributes.walkSpeed;
        runSpeed = attributes.runSpeed;
        _sneakSpeed = attributes.sneakSpeed;
        strength = attributes.strength;
        currentSpeed = standardSpeed;

        availableActions = new List<ActionWrapper>();
        for (int i = 0; i < attributes.innateActions.Length; i++)
        {
            availableActions.Add(attributes.innateActions[i]);
        }
        MeshFilter myMesh = GetComponent<MeshFilter>();
        myMesh.mesh = attributes.mesh;
    }
}
