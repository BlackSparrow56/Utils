using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Instructions.Kinds;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Instructions
{
    /// <summary>
    /// �����, ����������� ����������.
    /// </summary>
    [AddComponentMenu("Utils/Instructions/Executor")]
    public class Executor : MonoBehaviour
    {
        [SerializeField] private List<StringInstruction> stringInstructions;

        // ��������� ���������� ������ ������� ����������� ������ ����. ����� ��� �����������, ��������� � ���������.
        private readonly List<InstructionsQueue> _instructionsQueues = new List<InstructionsQueue>();
        // ��� ���������� ����������� ������ ����.
        private readonly List<InstructionBase> _everyFrameInstructions = new List<InstructionBase>();

        public void ExecuteStringInstruction(string text)
        {
            var instruction = stringInstructions.FirstOrDefault(value => value.Name == text);
            instruction.TryExecute();
        }

        public void AddQueue(InstructionsQueue queue)
        { 
            _instructionsQueues.Add(queue);
        }

        public void RemoveQueue(InstructionsQueue queue)
        {
            _instructionsQueues.Remove(queue);
        }

        public ConditionInstruction AddConditionInstruction(Func<bool> condition, Action action, bool selfDestroy = false)
        {
            var instruction = new ConditionInstruction(condition, action, selfDestroy);
            _everyFrameInstructions.Add(instruction);

            return instruction;
        }

        public KeyInstruction AddKeyInstruction(KeyCode keyCode, EKeyState state, Action action, bool selfDestroy = false)
        {
            var instruction = new KeyInstruction(keyCode, state, action, selfDestroy);
            _everyFrameInstructions.Add(instruction);

            return instruction;
        }

        public DelayInstruction AddDelayInstruction(float delay, Action action, bool selfDestroy = false)
        {
            var instruction = new DelayInstruction(delay, action, selfDestroy);
            _everyFrameInstructions.Add(instruction);

            return instruction;
        }

        public void RemoveInstruction(InstructionBase instruction)
        {
            _everyFrameInstructions.Remove(instruction);
        }

        private void Update()
        {
            var incomingEveryFrame = new List<InstructionBase>(_everyFrameInstructions);
            foreach (var instruction in incomingEveryFrame)
            {
                bool executed = instruction.TryExecute();

                if (executed && instruction.SelfDestroy)
                {
                    instruction.OnDestroy.Invoke();
                    _everyFrameInstructions.Remove(instruction);
                }
            }

            var incomingQueues = new List<InstructionsQueue>(_instructionsQueues);
            foreach (var queue in incomingQueues)
            {
                queue.TryExecuteLast(out bool last);
                if (last)
                {
                    _instructionsQueues.Remove(queue);
                }
            }
        }
    }
}