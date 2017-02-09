using UnityEngine;
using System.Collections;
using Stormancer;

public class TestConnection : MonoBehaviour {
    private void Awake()
    {
        MainThread.Initialize();
        UniRx.MainThreadDispatcher.Initialize();
    }

    // Use this for initialization
    void Start () {
        var sceneBehaviour = GetComponent<Stormancer.StormancerSceneBehaviour>();
        sceneBehaviour.ConfigureScene(s => s.AddRoute("echo", packet => { }));

        sceneBehaviour.Connect().ContinueWith(t =>
        {
            MainThread.Post(() =>
            {
                if(t.IsFaulted)
                {
                    Debug.LogError(t.Exception);
                }
                else
                {
                    Debug.Log("connected");
                }
            });
        });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
