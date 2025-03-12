using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomProperties : MonoBehaviour
{
    [SerializeField]
    private int m_RoomID = -1;
    [SerializeField]
    List<GameObject> AdjacentRooms;
}
