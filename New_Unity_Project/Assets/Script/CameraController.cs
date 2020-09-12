using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera Camera;
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = player.position;
        position.Set(player.position.x, player.position.y, -10);
        Camera.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
