using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTrigger2 : MonoBehaviour

{

public SceneChangeController2 sceneChangeController2;
public string destinationSceneName;

public bool fromKitchen; // Set this in the Inspector based on the direction
public bool fromHallway;
public bool fromBathroom;
public bool fromLivingRoom;

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (destinationSceneName == "Hallway2")
        {
            sceneChangeController2.KitchenToHallway(destinationSceneName, fromKitchen);
        }
        else if (destinationSceneName == "LivingRoom2")
        {
            sceneChangeController2.KitchenToLivingRoom(destinationSceneName, fromKitchen);
        }
        else if (destinationSceneName == "Kitchen2")
        {
            sceneChangeController2.HallwayToKitchen(destinationSceneName, fromHallway);
        }
        else if (destinationSceneName == "LivingRoom2")
        {
                sceneChangeController2.HallwayToLivingRoom(destinationSceneName, fromHallway);
        }
        else if (destinationSceneName == "Bathroom2")
        {
                sceneChangeController2.HallwayToBathroom(destinationSceneName, fromHallway);
        }
        else if (destinationSceneName == "Entrance2")
        {
                sceneChangeController2.HallwayToEntrance(destinationSceneName, fromHallway);
        }
        else if (destinationSceneName == "Hallway2")
        {
                sceneChangeController2.BathroomToHallway(destinationSceneName, fromBathroom);
        }
        else if (destinationSceneName == "Hallway2")
        {
                sceneChangeController2.LivingRoomToHallway(destinationSceneName, fromLivingRoom);
        }
        else if (destinationSceneName == "Kitchen2")
        {
                sceneChangeController2.LivingRoomToKitchen(destinationSceneName, fromLivingRoom);
        }

    }

}

}

