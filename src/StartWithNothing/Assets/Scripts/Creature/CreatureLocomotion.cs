using System;
using UnityEngine;

public class CreatureLocomotion : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _enabled;
    private float _magnitude = 20f;
    private int _itemHit = 0;
    private bool _jumpEnabled;
    private float _jumpCooldown = 0f;

    public event EventHandler Moved;
    public event EventHandler EnlightenmentAchieved;

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
            if (horiz > 0.1)
            {
                Moved?.Invoke(this, EventArgs.Empty);
            }

            if (_jumpCooldown > 0)
            {
                _jumpCooldown -= Time.deltaTime;
                if (_jumpCooldown < 0)
                {
                    _jumpCooldown = 0;
                }
            }

            if (_jumpEnabled && _jumpCooldown == 0 && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
            {
                _jumpCooldown = 1;
                _rb.AddForce(Vector3.up * _magnitude / 2, ForceMode.VelocityChange);
            }
        }
    }

    internal void ItemPickup()
    {
        if (_itemHit >= 10)
        {
            return;
        }

        _itemHit++;
        if (_itemHit >= 10)
        {
            EnlightenmentAchieved?.Invoke(this, EventArgs.Empty);
        }
    }

    internal void EnableJump(bool enable)
    {
        _jumpEnabled = enable;
    }

    public void EnableMovement(bool enable)
    {
        _enabled = enable;
        _rb.isKinematic = !enable;
    }
}
