using UnityEngine;

public class StrangeObject : MonoBehaviour
{
    public GameObject explosion;

    public void OnCollisionEnter(Collision c)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
