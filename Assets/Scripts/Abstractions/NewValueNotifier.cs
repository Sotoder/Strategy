
using System;
using UniRx;

namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : BaseAwaiter<TAwaited>
    {
        private TAwaited _result;
        public NewValueNotifier(StatelessScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _statelessSubscribtion = scriptableObjectValueBase.Subscribe(ONNewValue);
            _isStateless = true;
        }

        public NewValueNotifier(StatefulScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _statefulSubscribtion = scriptableObjectValueBase.Subscribe(ONNewValue);
        }

        protected override void ONNewValue(TAwaited obj)
        {
            _result = obj;
            base.ONNewValue(obj);
        }
        public override TAwaited GetResult() => _result;
    }
}