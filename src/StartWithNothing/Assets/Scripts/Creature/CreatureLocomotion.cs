using System.Collections;
using UnityEngine;

public class CreatureLocomotion : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _enabled;
    private float _magnitude = 20f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_enabled)
        {
            var horiz = Input.GetAxis("Horizontal");
            var force = Vector3.right * horiz * _magnitude * Time.deltaTime;
            _rb.AddForce(force, ForceMode.VelocityChange);
        }
    }

    public void EnableMovement(bool enable)
    {
        _enabled = enable;
        _rb.isKinematic = !enable;
    }
}
