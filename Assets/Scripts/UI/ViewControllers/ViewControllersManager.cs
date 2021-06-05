using UnityEngine;
using ESparrow.Utils.Patterns.CommandPattern;

namespace ESparrow.Utils.UI.ViewControllers
{
    public static class ViewControllersManager
    {
        // ����������� ������� ������, ������� � ������ ������ ����� ��� ����������������� �������� ����.
        private static readonly CommandExecutor _commandExecutor = new CommandExecutor();

        // ������� ViewController. ������� null �� ������� ������ ������ Open.
        private static ViewControllerBase _currentViewController;

        static ViewControllersManager()
        {
            _commandExecutor.OnEmptyUndoExecuted += () => _currentViewController.SetActive(false);
        }
        
        public static bool IsCurrent(ViewControllerBase viewController)
        {
            return _currentViewController != null && _currentViewController.Equals(viewController);
        }

        /// <summary>
        /// ��������� ����. ���� leaveOn - false, �� ��� �������� ���������� ���� ��� ���������.
        /// </summary>
        public static void Open(ViewControllerBase viewController, bool closePrevious)
        {
            var tempCurrent = _currentViewController;

            var command = new Command(Open, Close);
            _commandExecutor.Execute(command);

            _currentViewController = viewController;

            void Open()
            {
                if (closePrevious)
                {
                    tempCurrent?.SetActive(false);
                }

                viewController.SetActive(true);
            }

            void Close()
            {
                if (closePrevious)
                {
                    tempCurrent?.SetActive(true);
                    _currentViewController = tempCurrent;
                }

                viewController.SetActive(false);
            }
        }

        /// <summary>
        /// ��������� ������� ���� � ��������� ����������.
        /// </summary>
        public static void Back()
        {
            _commandExecutor.Undo();
        }
    }
}
