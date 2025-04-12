namespace AtsuvancedSceneManager.Core
{
    public interface ISceneLifeCycleManager
    {
        public string SceneName { get; }
        public void OnLoaded<T>(in T data) where T : ISceneData;
        public void OnUnLoaded();
    }
}