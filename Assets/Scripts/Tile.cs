﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlight;
    public bool hasBuilding;

    // toggles the tile highlight to show where we can place a building
    public void ToggleHighlight (bool toggle)
    {
        highlight.SetActive(toggle);
    }

    // can this tile be highlighted based on a given position
    public bool CanBeHighlighted (Vector3 potentialPosition)
    {
        return transform.position == potentialPosition && !hasBuilding;
    }

    void OnMouseDown ()
    {
        // place down a building on this tile
        if(GameManager.instance.placingBuilding && !hasBuilding)
            Map.instance.CreateNewBuilding(GameManager.instance.curSelectedBuilding, transform.position);
    }
}