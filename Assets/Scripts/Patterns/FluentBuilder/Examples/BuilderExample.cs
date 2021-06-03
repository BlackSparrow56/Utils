using UnityEngine;

namespace ESparrow.Utils.Patterns.FluentBuilder.Examples
{
    [AddComponentMenu("ESparrow/Utils/Patterns/FluentBuilder/Examples/BuilderExample")]
    public class BuilderExample : MonoBehaviour
    {
        private const string DefaultName = "DefaultName";
        private const int DefaultAge = 10;
        private const string DefaultMessage = "DefaultMessage";

        private ConcreteInstance DefaultWay()
        {
            return new ConcreteInstance(DefaultName, DefaultAge, DefaultMessage);
        }

        // ������ ������ ������� ��������� ������ ConcreteInstance � ������� �������.
        private ConcreteInstance FirstWay()
        {
            var builder = ConcreteInstance.CreateBuilder().SetName(DefaultName).SetAge(DefaultAge).SetMessage(DefaultMessage);
            var instance = builder.Build();

            return instance;
        }

        private ConcreteInstance SecondWay()
        {
            var builder = new ConcreteBuilder().SetName(DefaultName).SetAge(DefaultAge).SetMessage(DefaultMessage);
            var instance = builder.Build();

            return instance;
        }

        private void Start()
        {
            // � ������� ��������� ���������� ���������. ��� ������� ��� ����, ����� ��������, ��� ��������� � �������� � ��� �������� ��������, �� 
            // � ��������� ������� ������������ �������� �� ������� �������. ���� �� � ������ ���� ���� ������ �����, ��� � �������� ��� �� ���������� � ��������.

            Debug.Log($"Default Way:");
            var defaultWay = DefaultWay();
            defaultWay.Log();

            Debug.Log($"First Way With Builder:");
            var firstWay = FirstWay();
            firstWay.Log();

            Debug.Log($"Second Way With Builder");
            var secondWay = SecondWay();
            secondWay.Log();
        }
    }
}
