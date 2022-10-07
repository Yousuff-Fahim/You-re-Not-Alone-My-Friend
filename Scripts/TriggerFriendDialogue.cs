using UnityEngine;

public class TriggerFriendDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject Dialoguepanel;
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Friend")
        {
            FindObjectOfType<FindFriend>().StartDialogue(dialogue);
            Dialoguepanel.SetActive(true);
        }
    }
}
