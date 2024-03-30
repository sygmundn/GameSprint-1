using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2GrandpaDialogue3 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation grandpaConversation;
    private bool playerInRange = false;

    private void Start()
    {
        grandpaConversation = dialogueObject.GetComponent<NPCConversation>();
        if (grandpaConversation == null)
        {
            Debug.LogError("NPCConversation component not found on " + dialogueObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && ((GameManager2.Instance.spokeToGrandpa2 >= 2 && GameManager2.Instance.spokeToMom3 >= 1)) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(grandpaConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager2.Instance.spokeToGrandpa3 += 1;

        }
    }
}