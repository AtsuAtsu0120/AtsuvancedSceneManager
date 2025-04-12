namespace AtsuvancedSceneManager.Core
{
    public interface ISceneLifeCycleManager
    {
        public string SceneName { get; }
        public void OnLoaded(in ISceneData data);
        public void OnUnLoaded();
    }
}