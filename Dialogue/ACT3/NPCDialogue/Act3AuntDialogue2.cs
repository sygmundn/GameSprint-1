using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3AuntDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation auntConversation;
    private bool playerInRange = false;

    private void Start()
    {
        auntConversation = dialogueObject.GetComponent<NPCConversation>();
        if (auntConversation == null)
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

        // Check player interaction
        if (playerInRange && Input.GetKeyDown(KeyCode.Return) && GameManager3.Instance.spokeToBrother1 && !GameManager3.Instance.spokeToAunt2)
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(auntConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager3.Instance.spokeToAunt2 = true;

        }
    }
}