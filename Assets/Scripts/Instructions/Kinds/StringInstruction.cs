using System;
using UnityEngine;
using UnityEngine.Events;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// ��� ����������, ������� ����� ��������� � ����������.
    /// ���������� � ���� ����� ����� ������-���, � ����� Executor'�.
    /// </summary>
    [Serializable]
    public class StringInstruction : InstructionBase
    {
        [SerializeField] private string name;
        [SerializeField] private UnityEvent unityEvent;

        public string Name => name;

        protected override Action Action => unityEvent.Invoke;
        protected override Func<bool> Condition => () => true;

        public StringInstruction
        (
            string name, 
            UnityEvent unityEvent, 
            bool selfDestroy
        ) : base(unityEvent.Invoke, selfDestroy)
        {
            this.name = name;
        }

        public override bool TryExecute()
        {
            return base.TryExecute();
        }
    }
}
