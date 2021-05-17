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

        public ConditionInstruction(Func<bool> condition, Action action) : base(action)
        {
            _condition = condition;
        }

        public ConditionInstruction(Func<bool> condition, Action action, bool selfDestroy) : base(action, selfDestroy)
        {
            _condition = condition;
        }
    }
}
