using System.Collections;
using UnityEngine;

public class GlobalCoroutineRunner : MonoBehaviour
{
    public static GlobalCoroutineRunner Instance {get; private set;}

    private class Runner : MonoBehaviour { }

    private static Runner _runner;

    private void Awake()
    {
        Instance = this;
    }

    public static Coroutine MyStartCoroutine(IEnumerator couroutine)
    {
        return GetRunner().StartCoroutine(couroutine);
    }

    private static Runner GetRunner()
    {
        if (_runner == null)
        {
            GameObject go = new GameObject("GlobalCoroutineRunner");
            // Делаем объект постоянным
            GameObject.DontDestroyOnLoad(go);
            _runner = go.AddComponent<Runner>();
        }
        return _runner;
    }
}
