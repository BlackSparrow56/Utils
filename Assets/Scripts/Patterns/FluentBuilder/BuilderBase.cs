using System;
using ESparrow.Utils.Patterns.FluentBuilder.Interfaces;

namespace ESparrow.Utils.Patterns.FluentBuilder
{
    /// <summary>
    /// �����, ����������� ��������� ������������� ����������� �������, �� ��������� �������� ������������.
    /// </summary>
    public abstract class BuilderBase<T> : IBuilder<T> where T : new() 
    {
        protected virtual event Action<T> OnInstanceBuilded = _ => { };

        protected T _instance = new T();

        public T Build()
        {
            OnInstanceBuilded.Invoke(_instance);

            return _instance;
        }
    }
}
