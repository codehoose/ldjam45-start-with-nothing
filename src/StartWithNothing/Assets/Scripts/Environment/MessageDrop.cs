using UnityEngine;

public class MessageDrop : MonoBehaviour
{
    public GameObject _groundHit;

    public GameObject _playerHit;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player" && c.transform.position.y > 0)
        {
            Instantiate(_playerHit);
            var locomotion = c.gameObject.GetComponent<CreatureLocomotion>();
            locomotion.ItemPickup();
        }
        else
        {
            Instantiate(_groundHit);
        }
    }
}
