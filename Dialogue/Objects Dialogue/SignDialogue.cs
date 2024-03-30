using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class SignDialogue : MonoBehaviour
{

    public GameObject dialogueObject; // Reference to the IESnowmanDialogue object
    private NPCConversation signConversation;
    private bool playerInRange = false;

    private void Start()
    {
        signConversation = dialogueObject.GetComponent<NPCConversation>();
        if (signConversation == null)
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
        if (playerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            ConversationManager.Instance.StartConversation(signConversation);
        }

        if (playerInRange)
        {
            Debug.Log("Player in range");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter key pressed");
                ConversationManager.Instance.StartConversation(signConversation);
            }
        }

    }
}
