using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject buildingButtons;

    public TextMeshProUGUI foodAndMetalText;
    public TextMeshProUGUI oxygenAndEnergyText;

    public TextMeshProUGUI curTurnText;

    public static UI instance;

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        curTurnText.text = "Turn " + GameManager.instance.curTurn;
    }

    // called when the "End Turn" button is pressed
    public void OnEndTurnButton ()
    {
        GameManager.instance.EndTurn();
        curTurnText.text = "Turn " + GameManager.instance.curTurn;
    }

    // called when we select a building (disables the buttons)
    public void ToggleBuildingButtons (bool toggle)
    {
        buildingButtons.SetActive(toggle);
    }

    // called when we click the solar panel button
    public void OnClickSolarPanelButton ()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.SolarPanel);
        ToggleBuildingButtons(false);
    }

    // called when we click the greenhouse button
    public void OnClickGreenhouseButton()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.Greenhouse);
        ToggleBuildingButtons(false);
    }

    // called when we click the mine button
    public void OnClickMineButton()
    {
        GameManager.instance.SetPlacingBuilding(BuildingType.Mine);
        ToggleBuildingButtons(false);
    }

    // called when we place a building or the turn has ended
    public void UpdateResourceText ()
    {
        string food = string.Format("{0} ({1}{2})", GameManager.instance.curFood, GameManager.instance.foodPerTurn < 0 ? "" : "+", GameManager.instance.foodPerTurn);
        string metal = string.Format("{0} ({1}{2})", GameManager.instance.curMetal, GameManager.instance.metalPerTurn < 0 ? "" : "+", GameManager.instance.metalPerTurn);
        string oxygen = string.Format("{0} ({1}{2})", GameManager.instance.curOxygen, GameManager.instance.oxygenPerTurn < 0 ? "" : "+", GameManager.instance.oxygenPerTurn);
        string energy = string.Format("{0} ({1}{2})", GameManager.instance.curEnergy, GameManager.instance.energyPerTurn < 0 ? "" : "+", GameManager.instance.energyPerTurn);

        foodAndMetalText.text = food + "\n" + metal;
        oxygenAndEnergyText.text = oxygen + "\n" + energy;
    }
}