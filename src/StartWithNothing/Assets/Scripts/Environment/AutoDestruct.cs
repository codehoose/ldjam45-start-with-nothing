using System.Collections;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    public float _duration = 3f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_duration);
        Destroy(gameObject);
    }
}
