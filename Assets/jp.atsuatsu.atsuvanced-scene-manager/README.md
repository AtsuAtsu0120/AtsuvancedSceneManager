# AtsuvancedSceneManager
AdvancedSceneMangerと言い張るには自信なかったので、Atsuvancedです。

## コンセプト
Unity標準のSceneManagerと同じように使えるようにしつつ、様々な機能を実装しています。

## 追加される機能
- 文字列ではなく型を使用したシーン遷移
- シーン間のデータ移行
- シーンのライフサイクル管理

## 使い方
### シーンのデータ管理
```csharp
[Serializable]
public class TestSceneData : ScriptableObject, ISceneData
{
    [SerializeField] public string PlayerName;
}
```

### シーンのライフサイクル定義
```csharp
public class TestSceneLifeCycleManager : ISceneLifeCycleManager
{
    public string SceneName => "TestScene";

    public void OnLoaded(in ISceneData data)
    {
        var entoryPoint = Object.FindObjectsByType<EntryPoint>(FindObjectsSortMode.None);
        entoryPoint.Inizialize(data);
    }

    public void OnUnLoaded()
    {
        
    }
}
```