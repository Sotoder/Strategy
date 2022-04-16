using System;
using UniRx;

namespace Utils
{
    public class StatelessScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
    {
        private Subject<T> _data = new Subject<T>();
        public override void SetValue(T value)
        {
            base.SetValue(value);
            _data.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<T> observer) =>
        _data.Subscribe(observer);
    }
}