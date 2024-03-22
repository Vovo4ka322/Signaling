using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;


    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotationByX = Input.GetAxis(Horizontal);

        transform.Rotate(rotationByX * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}
