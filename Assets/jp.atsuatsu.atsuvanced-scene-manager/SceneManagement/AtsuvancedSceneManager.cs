using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AtsuvancedSceneManager.Core
{
    public static class AtsuvancedSceneManager
    {
        #if UNITY_EDITOR
        /// <summary>
        /// falseならシーンが直接起動されているので、デバックモードとして起動する
        /// </summary>
        public static bool HasSceneLifeTimeManager => _cachedSceneLifeCycleManager is not null;
        #endif
        
        private static ISceneLifeCycleManager _cachedSceneLifeCycleManager;
    
        public static async UniTaskVoid LoadSceneAsync<T>(ISceneData data) where T : ISceneLifeCycleManager, new()
        {
            _cachedSceneLifeCycleManager?.OnUnLoaded();
            _cachedSceneLifeCycleManager = new T();
            
            await SceneManager.LoadSceneAsync(_cachedSceneLifeCycleManager.SceneName);
            _cachedSceneLifeCycleManager.OnLoaded(data);
        }
    }
}