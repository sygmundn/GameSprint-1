using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController3 : MonoBehaviour
{
    public Transform kitchenToHallway;
    public Transform kitchenToLivingRoom;

    public Transform hallwayToKitchen;
    public Transform hallwayToLivingRoom;
    public Transform hallwayToBathroom;
    public Transform hallwayToEntrance;

    public Transform bathroomToHallway;
    public Transform livingRoomToKitchen;
    public Transform livingRoomToHallway;


    public void KitchenToHallway(string Hallway, bool fromKitchen)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromKitchen)
        {
            entryPoint = kitchenToHallway.position; // Note the change here
        }


        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Hallway3"); // Use the provided scene name
    }

    public void KitchenToLivingRoom(string LivingRoom, bool fromKitchen)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromKitchen)
        {
            entryPoint = kitchenToLivingRoom.position;
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("LivingRoom3");

    }

    public void HallwayToKitchen(string Kitchen, bool fromHallway)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromHallway)
        {
            entryPoint = hallwayToKitchen.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Kitchen3"); // Use the provided scene name
    }

    public void HallwayToLivingRoom(string LivingRoom, bool fromHallway)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromHallway)
        {
            entryPoint = hallwayToLivingRoom.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("LivingRoom3"); // Use the provided scene name
    }

    public void HallwayToBathroom(string Bathroom, bool fromHallway)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromHallway)
        {
            entryPoint = hallwayToBathroom.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Bathroom3"); // Use the provided scene name
    }

    public void HallwayToEntrance(string Entrance, bool fromHallway)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromHallway)
        {
            entryPoint = hallwayToEntrance.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Entrance3"); // Use the provided scene name
    }

    public void BathroomToHallway(string Hallway, bool fromBathroom)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromBathroom)
        {
            entryPoint = bathroomToHallway.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Hallway3"); // Use the provided scene name
    }

    public void LivingRoomToHallway(string Hallway, bool fromLivingRoom)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromLivingRoom)
        {
            entryPoint = livingRoomToHallway.position; // Note the change here
            Debug.Log("LivingRoomToHallway: entryPoint = " + entryPoint);
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Hallway3"); // Use the provided scene name
    }

    public void LivingRoomToKitchen(string Kitchen, bool fromLivingRoom)
    {
        Vector2 entryPoint = Vector2.zero;

        if (fromLivingRoom)
        {
            entryPoint = livingRoomToKitchen.position; // Note the change here
        }

        PlayerController.SetPlayerEntryPoint(entryPoint);

        SceneManager.LoadScene("Kitchen3"); // Use the provided scene name
    }


}