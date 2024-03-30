using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2UncleDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation uncleConversation;
    private bool playerInRange = false;

    private void Start()
    {
        uncleConversation = dialogueObject.GetComponent<NPCConversation>();
        if (uncleConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (GameManager2.Instance.spokeToBrother2) && ((GameManager2.Instance.spokeToUncle2 < 1) || (GameManager2.Instance.spokeToMom2 < 1))
            && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(uncleConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
                GameManager2.Instance.spokeToUncle2 += 1;
                Debug.Log("Spoke to Uncle2: " + GameManager2.Instance.spokeToUncle2); // Display the count

            }

        }
    }
}