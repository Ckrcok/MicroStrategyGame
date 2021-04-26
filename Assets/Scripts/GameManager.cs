using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int curTurn;
    public bool placingBuilding;
    public BuildingType curSelectedBuilding;

    [Header("Current Resources")]
    public int curFood;
    public int curMetal;
    public int curOxygen;
    public int curEnergy;

    [Header("Round Resource Increase")]
    public int foodPerTurn;
    public int metalPerTurn;
    public int oxygenPerTurn;
    public int energyPerTurn;

    public static GameManager instance;

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        // updating the resource UI
        UI.instance.UpdateResourceText();
    }

    // called when the "End Turn" button is pressed
    public void EndTurn ()
    {
        // give resources
        curFood += foodPerTurn;
        curMetal += metalPerTurn;
        curOxygen += oxygenPerTurn;
        curEnergy += energyPerTurn;

        // update the resource UI
        UI.instance.UpdateResourceText();

        curTurn++;

        // enable the building buttons
        UI.instance.ToggleBuildingButtons(true);

        // enable usable tiles
        Map.instance.EnableUsableTiles();
    }

    // called when we click on a building button to place it
    public void SetPlacingBuilding (BuildingType buildingType)
    {
        placingBuilding = true;
        curSelectedBuilding = buildingType;
    }

    // called when a new building has been created and placed down
    public void OnCreatedNewBuilding (Building building)
    {
        // resource the building produces
        if(building.doesProduceResource)
        {
            switch(building.productionResource)
            {
                case ResourceType.Food:
                    foodPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Metal:
                    metalPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Oxygen:
                    oxygenPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Energy:
                    energyPerTurn += building.productionResourcePerTurn;
                    break;
            }
        }

        // resource the building may cost
        if(building.hasMaintenanceCost)
        {
            switch(building.maintenanceResource)
            {
                case ResourceType.Food:
                    foodPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Metal:
                    metalPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Oxygen:
                    oxygenPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Energy:
                    energyPerTurn -= building.maintenanceResourcePerTurn;
                    break;
            }
        }

        placingBuilding = false;
        // update the resource UI
        UI.instance.UpdateResourceText();
    }
}