using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum DoorDirection { Top, Bottom, Left, Right };
    // Top -> Spawn room at Top with Bottom door
    // Bottom -> Spawn room at Bottom with Top door
    // Left -> Spawn room at Left with Right door
    // Right -> Spawn room at Right with Left door

    public DoorDirection direction;

    private RoomTemplates roomTemplates;
    private bool hasRoomSpawned = false;

    private void Awake()
    {
        roomTemplates = FindObjectOfType<RoomTemplates>();
    }

    void Start()
    {
        direction = DoorDirection.Top;
        Invoke("SpawnRoom", 0.5f);
    }

    void SpawnRoom()
    {
        if (hasRoomSpawned)
            return;

        GameObject room;
        int randomNo;
        if (direction == DoorDirection.Top)
        {
            // spawn room with BOTTOM door
            randomNo = Random.Range(0, roomTemplates.bottomRooms.Length);
            room = Instantiate(roomTemplates.bottomRooms[randomNo], transform.position, Quaternion.identity);
        }
        else if (direction == DoorDirection.Bottom)
        {
            // spawn room with TOP door
            randomNo = Random.Range(0, roomTemplates.topRooms.Length);
            room = Instantiate(roomTemplates.topRooms[randomNo], transform.position, Quaternion.identity);
        }
        else if (direction == DoorDirection.Left)
        {
            // spawn room with RIGHT door
            randomNo = Random.Range(0, roomTemplates.rightRooms.Length);
            room = Instantiate(roomTemplates.rightRooms[randomNo], transform.position, Quaternion.identity);
        }
        else if (direction == DoorDirection.Right)
        {
            // spawn room with LEFT door
            randomNo = Random.Range(0, roomTemplates.leftRooms.Length);
            room = Instantiate(roomTemplates.leftRooms[randomNo], transform.position, Quaternion.identity);
        }
        else
            GameManager.DebugLog("Unknown Direction");

        hasRoomSpawned = true;
    }
}
