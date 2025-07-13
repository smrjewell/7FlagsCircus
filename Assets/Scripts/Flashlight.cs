using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Settings")]
    [SerializeField] private GameObject flashlightPrefab; // Reference to the flashlight prefab
    [SerializeField] private float battery = 100f; // Battery percentage (0-100)
    [SerializeField] private float batteryDepletionSpeed = 0.7f; // Rate at which the battery drains per second
    [SerializeField] private KeyCode switchKey = KeyCode.F; // Key to toggle the flashlight on/off
    private bool on;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI batteryText; // UI Text to display battery percentage

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(switchKey))
        //{
        //    ToggleFlashlight(); // Toggle flashlight state
        //}

        if (on && battery > 0)
        {
            battery -= batteryDepletionSpeed * Time.deltaTime; // Deplete battery while flashlight is on
        }
        else if (battery < 0.01f)
        {
            on = false; // Turn off flashlight if battery is depleted
        }

        batteryText.text = $"Battery: {(int)battery}%";

        flashlightPrefab.SetActive(on); // Toggle flashlight visibility
    }

    private void ToggleFlashlight()
    {
        on = !on;
    }
}
