using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2AuntDialogue3 : MonoBehaviour
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && ((GameManager2.Instance.spokeToAunt2 >= 1 && GameManager2.Instance.spokeToCousin2 >= 2)) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(auntConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager2.Instance.spokeToAunt3 += 1;

        }
    }
}