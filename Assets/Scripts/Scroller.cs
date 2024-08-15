using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Transform ChuncksContainer;
    [SerializeField] private Transform CollectabeContainer;

    public void MoveForward(Vector3 velocity)
    {
        foreach (Transform child in ChuncksContainer)
            child.position += velocity;
        foreach (Transform child in CollectabeContainer)
            child.position += velocity;

    }
}
