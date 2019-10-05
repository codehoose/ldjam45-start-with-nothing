using UnityEngine;

public class NarrationBehaviour : MonoBehaviour
{
    private ActionRunner _runner = null;

    protected ActionRunner Runner
    {
        get
        {
            if (_runner == null)
            {
                _runner = GetComponent<ActionRunner>();
            }

            return _runner;
        }
    }

    void Start()
    {
        _runner.Run();
    }
}
