﻿using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Instructions;
using ESparrow.Utils.Instructions.Kinds;

namespace ESparrow.Utils.Patterns.Command.Example
{
    [AddComponentMenu("ESparrow/Utils/Patterns/Command/Example")]
    public class KeyCommands : MonoBehaviour
    {
        [SerializeField] private KeyCode incrementKey;
        [SerializeField] private KeyCode decrementKey;

        [SerializeField] private KeyCode undoKey;
        [SerializeField] private KeyCode redoKey;

        private readonly InstructionExecutor _instructionExecutor = new InstructionExecutor();
        private readonly CommandExecutor _commandExecutor = new CommandExecutor();

        private InstructionBase _incrementInstruction;
        private InstructionBase _decrementInstruction;
        private InstructionBase _undoInstruction;
        private InstructionBase _redoInstruction;

        private Command _incrementCommand;
        private Command _decrementCommand;

        private int _targetInt;

        private void Increment()
        {
            _commandExecutor.DoCommand(_incrementCommand);
        }

        private void Decrement()
        {
            _commandExecutor.DoCommand(_decrementCommand);
        }

        private void IncrementValue()
        {
            _targetInt++;
            Debug.Log(_targetInt);
        }

        private void DecrementValue()
        {
            _targetInt--;
            Debug.Log(_targetInt);
        }

        private void Undo()
        {
            Debug.Log($"Undo");
            _commandExecutor.Undo();
        }

        private void Redo()
        {
            Debug.Log($"Redo");
            _commandExecutor.Redo();
        }

        private void OnEnable()
        {
            _incrementInstruction = new KeyInstruction(incrementKey, EKeyState.Pressed, Increment);
            _decrementInstruction = new KeyInstruction(decrementKey, EKeyState.Pressed, Decrement);
            _undoInstruction = new KeyInstruction(undoKey, EKeyState.Pressed, Undo);
            _redoInstruction = new KeyInstruction(redoKey, EKeyState.Pressed, Redo);

            _instructionExecutor.AddInstruction(_incrementInstruction);
            _instructionExecutor.AddInstruction(_decrementInstruction);
            _instructionExecutor.AddInstruction(_undoInstruction);
            _instructionExecutor.AddInstruction(_redoInstruction);

            _incrementCommand = new Command(IncrementValue, DecrementValue);
            _decrementCommand = new Command(DecrementValue, IncrementValue);
        }

        private void OnDisable()
        {
            _instructionExecutor.RemoveInstruction(_incrementInstruction);
            _instructionExecutor.RemoveInstruction(_decrementInstruction);
            _instructionExecutor.RemoveInstruction(_undoInstruction);
            _instructionExecutor.RemoveInstruction(_redoInstruction);

            _incrementInstruction = null;
            _decrementInstruction = null;
            _undoInstruction = null;
            _redoInstruction = null;

            _incrementCommand = null;
            _decrementCommand = null;
        }
    }
}