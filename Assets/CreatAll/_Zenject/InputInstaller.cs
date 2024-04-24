using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
        .Bind<IInputProvider>() // IInputProvider‚ª‚ ‚é‚Æ‚«
        .To<NormalInputProvider>() // InputProvider‚ğ’“ü‚·‚é
        .AsCached(); // ¶¬Ï‚İ‚È‚çg‚¢‰ñ‚·
    }
}