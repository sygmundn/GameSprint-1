using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger3 : MonoBehaviour
{
    public SceneChangeController3 sceneChangeController3;
    public string destinationSceneName;

    public bool fromKitchen; // Set this in the Inspector based on the direction
    public bool fromHallway;
    public bool fromBathroom;
    public bool fromLivingRoom;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (destinationSceneName == "Hallway3")
            {
                sceneChangeController3.KitchenToHallway(destinationSceneName, fromKitchen);
            }
            else if (destinationSceneName == "LivingRoom3")
            {
                sceneChangeController3.KitchenToLivingRoom(destinationSceneName, fromKitchen);
            }
            else if (destinationSceneName == "Kitchen3")
            {
                sceneChangeController3.HallwayToKitchen(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "LivingRoom3")
            {
                sceneChangeController3.HallwayToLivingRoom(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "Bathroom3")
            {
                sceneChangeController3.HallwayToBathroom(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "Entrance3")
            {
                sceneChangeController3.HallwayToEntrance(destinationSceneName, fromHallway);
            }
            else if (destinationSceneName == "Hallway3")
            {
                sceneChangeController3.BathroomToHallway(destinationSceneName, fromBathroom);
            }
            else if (destinationSceneName == "Hallway3")
            {
                sceneChangeController3.LivingRoomToHallway(destinationSceneName, fromLivingRoom);
            }
            else if (destinationSceneName == "Kitchen3")
            {
                sceneChangeController3.LivingRoomToKitchen(destinationSceneName, fromLivingRoom);
            }

        }

    }
}