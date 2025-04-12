using AtsuvancedSceneManager.Core;
using UnityEngine;

namespace DefaultNamespace
{
    public class EntryPoint : MonoBehaviour
    {
        public void Initialize(ISceneData data)
        {
            var convertedData = (TestSceneData)data;
            // Initialization logic here
        }
    }
}