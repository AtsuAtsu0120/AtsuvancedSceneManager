using System;
using AtsuvancedSceneManager.Core;
using DefaultNamespace;
using UnityEngine;
using Object = UnityEngine.Object;

public class Something : MonoBehaviour
{

}

[Serializable]
public class TestSceneData : ScriptableObject, ISceneData
{
    [SerializeField] public string PlayerName;
}

public class TestSceneLifeCycleManager : ISceneLifeCycleManager
{
    public string SceneName => "TestScene";

    public void OnLoaded<T>(in T data) where T : ISceneData
    {
        var entoryPoint = Object.FindFirstObjectByType<EntryPoint>();
        entoryPoint.Initialize(data);
    }

    public void OnUnLoaded()
    {
        
    }
}
