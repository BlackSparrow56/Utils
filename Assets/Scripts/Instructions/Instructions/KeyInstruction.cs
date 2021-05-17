using System;
using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// ��� ����������, ���������� �� �������/�������/��������� �����-���� �� ������.
    /// </summary>
    public class KeyInstruction : InstructionBase
    {
        protected override Func<bool> Condition => () => _keyCode.IsKeyAtState(_targetState);

        private readonly KeyCode _keyCode;
        private readonly EKeyState _targetState;

        public KeyInstruction(KeyCode keyCode, EKeyState targetState, Action action) : base(action)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }

        public KeyInstruction(KeyCode keyCode, EKeyState targetState, Action action, bool selfDestroy) : base(action, selfDestroy)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }
    }
}
