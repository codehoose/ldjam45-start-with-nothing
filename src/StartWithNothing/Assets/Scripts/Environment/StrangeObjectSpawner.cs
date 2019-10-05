using System.Collections;
using UnityEngine;

public class StrangeObjectSpawner : MonoBehaviour
{
    private bool _enabled;
    private Coroutine _coroutine;
    private float count = 0f;

    public Vector3 _leftMost;
    public Vector3 _rightMost;
    public float _duration = 3f;

    public GameObject _strangeObjectPrefab;

    void Update()
    {
        var lerp = Mathf.PingPong(Time.time / _duration, 1);
        transform.position = Vector3.Lerp(_leftMost, _rightMost, lerp);
    }
    
    public void EnableDrop(bool enabled)
    {
        if (enabled && _coroutine == null)
        {
            _coroutine = StartCoroutine(DropItems());
        } 
        else if (_coroutine != null)
        {
            StopAllCoroutines();
            _coroutine = null;
        }
    }

    private IEnumerator DropItems()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(_strangeObjectPrefab, transform.position, Quaternion.identity);
        }
    }
}
