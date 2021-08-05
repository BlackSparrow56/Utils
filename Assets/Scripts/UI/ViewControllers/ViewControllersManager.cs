using System.Linq;
using System.Collections.Generic;
using ESparrow.Utils.Patterns.CommandPattern;

namespace ESparrow.Utils.UI.ViewControllers
{
    public class ViewControllersManager
    {
        private static readonly ViewControllersManager _main;

        // ����������� ������� ������, ������� � ������ ������ ����� ��� ����������������� �������� ����.
        private readonly CommandExecutor _commandExecutor = new CommandExecutor();

        // ������� ViewController. ������� null �� ������� ������ ������ Open.
        private ViewControllerBase _currentViewController;

        private List<ViewControllerBase> _viewControllers;

        private List<ViewControllerBase> ActiveViewControllers => _viewControllers.Where(value => value.Active).ToList();
        private List<ViewControllerBase> PassiveViewControllers => _viewControllers.Except(ActiveViewControllers).ToList();

        public static ViewControllersManager Main => _main;

        static ViewControllersManager()
        {
            _main = new ViewControllersManager();
        }

        public ViewControllersManager()
        {
            _viewControllers = new List<ViewControllerBase>();

            _commandExecutor.OnEmptyUndoExecuted += () => _currentViewController.SetActive(false);
        }
        
        public bool IsCurrent(ViewControllerBase viewController)
        {
            return _currentViewController != null && _currentViewController.Equals(viewController);
        }

        public void Register(ViewControllerBase viewController)
        {
            _viewControllers.Add(viewController);
        }

        public void Unregister(ViewControllerBase viewController)
        {
            _viewControllers.Remove(viewController);
        }

        /// <summary>
        /// ��������� ����. ���� leaveOn - false, �� ��� �������� ���������� ���� ��� ���������.
        /// </summary>
        public void Open(ViewControllerBase viewController, bool closePrevious)
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
        public void Back()
        {
            _commandExecutor.Undo();
        }

        public void Close()
        {
            _commandExecutor.Clear();
            ActiveViewControllers.ForEach(value => value.SetActive(false));
        }
    }
}
