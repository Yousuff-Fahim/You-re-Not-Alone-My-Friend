using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    public GameObject[] friendsList;

    void Start()
    {
        int friend = Random.Range(0, friendsList.Length);
        friendsList[friend].SetActive(true);
    }
}
