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
    
        public static async UniTaskVoid LoadSceneAsync<T, T2>(T2 data) where T : ISceneLifeCycleManager, new() where T2 : ISceneData
        {
            _cachedSceneLifeCycleManager?.OnUnLoaded();
            _cachedSceneLifeCycleManager = new T();
            
            await SceneManager.LoadSceneAsync(_cachedSceneLifeCycleManager.SceneName);
            _cachedSceneLifeCycleManager.OnLoaded(data);
        }

#if UNITY_EDIOR
        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoad()
        {
            _cachedSceneLifeCycleManager = null;
        }
#endif
    }
}