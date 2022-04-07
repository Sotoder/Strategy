
namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : BaseAwaiter<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;

        public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= ONNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override TAwaited GetResult() => _result;
    }
}