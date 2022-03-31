using System;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;

        private Action<IAttackCommand> _creationCallback;

        [Inject]
        private void Init(Vector3Value groundClicks) => groundClicks.OnValueChange += ONNewValue;

        [Inject]
        private void Init(SelectableEnemy enemyClicks) => enemyClicks.OnValueChange += ONNewEnemy;

        private void ONNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(groundClick)));
            _creationCallback = null;
        }

        private void ONNewEnemy(IAttackable enemy)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(enemy)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback) => _creationCallback = creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}
