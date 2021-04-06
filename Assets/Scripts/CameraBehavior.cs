using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z) + _offset;
    }
}
