using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool _enable = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform cameraHolder = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    private CharacterController _controller;
    public PlayerMovement _playerMovement;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerMovement = GetComponent<PlayerMovement>();
        startPos = _camera.localPosition;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void CheckMotion()
    {
        // float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;  //velocity x dan z tidak terbaca
        float speed = _playerMovement.horizontalVelocity.magnitude;

        ResetPosition();
        if (speed < toggleSpeed) return;
        if (!_controller.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, startPos, 1 * Time.deltaTime);
    }
    private void Update()
    {
        if (!_enable) return;
        CheckMotion();
        _camera.LookAt(FocusTarget());

    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 20.0f;
        return pos;
    }

}
