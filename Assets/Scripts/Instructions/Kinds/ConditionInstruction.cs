using System;

namespace ESparrow.Utils.Instructions.Kinds
{
    /// <summary>
    /// ����� ����������� ��� ����������, �� ��� �� � ����� �������������, ���� �� ����� "�������������" ��� ��������� ���� ����������.
    /// ������������ ���������� ������ � ��� ������, ���� ����������� ������ ���������� ���� ������ �� ��������. � ��������� - � �� ���������� ����.
    /// </summary>
    public class ConditionInstruction : InstructionBase
    {
        protected override Func<bool> Condition => _condition;

        private readonly Func<bool> _condition = () => false;

        public ConditionInstruction
        (
            Func<bool> condition, 
            Action action, 
            bool selfDestroy = false, 
            Action onDestroy = default
        ) : base(action, selfDestroy, onDestroy)
        {
            _condition = condition;
        }
    }
}
