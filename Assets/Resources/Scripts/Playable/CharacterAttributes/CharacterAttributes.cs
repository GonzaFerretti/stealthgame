﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "New Character")]
public class CharacterAttributes : ScriptableObject
{
    public float sneakSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float strength;
    public float bodyheight;
    public float whistleStrength;
    public ActionWrapper[] innateActions;
    public GameObject characterModel;
    public RuntimeAnimatorController animations;
}
