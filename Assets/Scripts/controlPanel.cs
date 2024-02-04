using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanel : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private Transform _transform;

    private void Awake()
    {
        _transform = gameObject.transform.GetChild(0).gameObject.transform;
    }

    private void Update()
    {
        gameObject.transform.GetChild(0).SetPositionAndRotation(_transform.position,new Quaternion(_transform.rotation.x,camera.transform.rotation.y,_transform.rotation.z,_transform.rotation.w));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
