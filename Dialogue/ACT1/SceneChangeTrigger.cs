using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    public SceneChangeController sceneChangeController;
    public string destinationSceneName;
    
    public bool fromKitchen; // Set this in the Inspector based on the direction
    public bool fromHallway;
    public bool fromBathroom;
    public bool fromLivingRoom;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (destinationSceneName == "Hallway1")
            {
                sceneChangeController.KitchenToHallway(destinationSceneName, fromKitchen);
            }
            else if (destinationSceneName == "LivingRoom1")
            {
                sceneChangeController.KitchenToLivingRoom(destinationSceneName, fromKitchen);
            }
            else if (destinationSceneName == "Kitchen1")
            {
                sceneChangeController.HallwayToKitchen(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "LivingRoom1")
            {
                sceneChangeController.HallwayToLivingRoom(destinationSceneName, fromHallway);   
            }
            else if (destinationSceneName == "Bathroom1")
            {
                sceneChangeController.HallwayToBathroom(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "Entrance1")
            {
                sceneChangeController.HallwayToEntrance(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "Hallway1")
            {
                sceneChangeController.BathroomToHallway(destinationSceneName, fromBathroom);
            }
            else if (destinationSceneName == "Hallway1")
            {
                sceneChangeController.LivingRoomToHallway(destinationSceneName, fromLivingRoom);
            }
            else if (destinationSceneName == "Kitchen1")
            {
                sceneChangeController.LivingRoomToKitchen(destinationSceneName, fromLivingRoom);
            }

        }

    }
}
