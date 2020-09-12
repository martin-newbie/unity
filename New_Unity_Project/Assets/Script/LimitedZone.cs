using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedZone : MonoBehaviour
{

    public GameObject shadow;
    public Transform player;

    [SerializeField]
    private float Speed;

    
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Speed);
    }
    private void FollowPlayer()
    {
        Vector3 position = player.position;
        position.Set(player.position.x, player.position.y, -10);
        gameObject.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
