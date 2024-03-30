using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MailboxDialogue : MonoBehaviour
{

    public GameObject dialogueObject; // Reference to the IESnowmanDialogue object
    private NPCConversation mailboxConversation;
    private bool playerInRange = false;

    private void Start()
    {
        mailboxConversation = dialogueObject.GetComponent<NPCConversation>();
        if (mailboxConversation == null)
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
            ConversationManager.Instance.StartConversation(mailboxConversation);
        }

        if (playerInRange)
        {
            Debug.Log("Player in range");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter key pressed");
                ConversationManager.Instance.StartConversation(mailboxConversation);
            }
        }

    }
}

