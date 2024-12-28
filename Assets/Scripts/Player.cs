using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField] private float _speed;
    private void Start()
    {
        _position = transform.position;
       
        Application.targetFrameRate = 60;
    }



    private void Update()
    {        
        if (Input.GetKey(KeyCode.W))
        {
            _position.z = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _position.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _position.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _position.x = +1;
        }
        _position = _position.normalized;
        transform.position += _position * _speed * Time.deltaTime;
        print(transform.position);

    }

}
