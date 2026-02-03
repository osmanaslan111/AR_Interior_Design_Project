using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    [Header("Product Prefabs")]
    public GameObject deskPrefab; 
    public GameObject lampPrefab;

    private GameObject selectedPrefab; // To store which product is selected
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        // Default product is the desk
        selectedPrefab = deskPrefab; 
    }

    // Methods to be called by UI Buttons
    public void SelectDesk() => selectedPrefab = deskPrefab;
    public void SelectLamp() => selectedPrefab = lampPrefab;

    void Update()
    {
        // Check if clicking on UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Pointer.current == null || !Pointer.current.press.wasPressedThisFrame)
            return;

        Vector2 touchPosition = Pointer.current.position.ReadValue();

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            // Remove old product before placing new one
            GameObject oldProduct = GameObject.FindWithTag("Product");
            if (oldProduct != null) Destroy(oldProduct);

            // Place selected product (Desk or Lamp)
            GameObject newObject = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
            newObject.tag = "Product"; // Crucial for Color Change
            
            Debug.Log("Analytics: Placed " + selectedPrefab.name);
        }
    }
}