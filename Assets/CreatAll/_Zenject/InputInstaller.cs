using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
        .Bind<IInputProvider>() // IInputProviderがあるとき
        .To<NormalInputProvider>() // InputProviderを注入する
        .AsCached(); // 生成済みなら使い回す
    }
}