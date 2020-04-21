﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableEnter : IActionInteractableObject
{
    InteractableEnterWrapper _wrapper;

    public InteractableEnter(InteractableEnterWrapper wrapper)
    {
        _wrapper = wrapper;
    }

    public void Do(InteractableObject obj)
    {
        Door door = obj as Door;

        if (door.mapAttributes == null)
        {
            door.mapAttributes = door.GenerateIndoorAttributes();
        }

        MapSetter mapSetter = MonoBehaviour.Instantiate(door.mapSetter);
        mapSetter.mapInfoKeeper = door.mapInfoKeeper;
        mapSetter.mapAttributes = door.mapAttributes;

        if(SceneManager.GetActiveScene().name == _wrapper.scenes[0])
        SceneManager.LoadScene(_wrapper.scenes[1]);
        else
        SceneManager.LoadScene(_wrapper.scenes[0]);

        mapSetter.mapInfoKeeper.previousMap = mapSetter.mapInfoKeeper.currentMap;
        mapSetter.mapInfoKeeper.currentMap = door.mapAttributes.mapName;

        mapSetter.CreateFloorWrapper();
    }
}