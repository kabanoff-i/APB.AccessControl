using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.ManageApp.Controls;
using APB.AccessControl.ManageApp.Forms;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для работы с представлением сотрудников (MVP паттерн)
    /// </summary>
    public class EmployeePresenter
    {
        private readonly IEmployeeView _view;
        private readonly EmployeeService _employeeService;

        private EmployeeDto _currentEmployee;
        private List<CardDto> _currentCards;

        public EmployeePresenter(IEmployeeView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _employeeService = new EmployeeService();

            // Подписываемся на события от представления
            _view.EmployeeSelected += OnEmployeeSelected;
            _view.CreateEmployee += OnCreateEmployee;
            _view.UpdateEmployee += OnUpdateEmployee;
            _view.DeleteEmployee += OnDeleteEmployee;
            _view.AssignCardToEmployee += OnAssignCardToEmployee;
            _view.DeleteCardFromEmployee += OnDeleteCardFromEmployee;
            _view.ActivateCard += OnActivateCard;
            _view.DeactivateCard += OnDeactivateCard;
            _view.CardInfoReceived += OnCardInfoReceived;
        }

        /// <summary>
        /// Загрузить список всех сотрудников
        /// </summary>
        public async Task LoadEmployeesAsync()
        {
            try
            {
                _view.SetBusy(true);
                var employees = await _employeeService.GetAllEmployeesAsync();
                _view.UpdateEmployeeList(employees);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки сотрудников: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Загрузить данные сотрудника по ID
        /// </summary>
        /// <param name="employeeId">ID сотрудника</param>
        public async Task LoadEmployeeByIdAsync(int employeeId)
        {
            try
            {
                _view.SetBusy(true);

                // Загружаем детальную информацию о сотруднике
                _currentEmployee = await _employeeService.GetEmployeeByIdAsync(employeeId);
                _view.ShowEmployeeDetails(_currentEmployee);

                // Загружаем карты сотрудника
                _currentCards = new List<CardDto>(await _employeeService.GetEmployeeCardsAsync(employeeId));
                _view.ShowEmployeeCards(_currentCards);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки данных сотрудника: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события выбора сотрудника
        /// </summary>
        private async void OnEmployeeSelected(object sender, int employeeId)
        {
            await LoadEmployeeByIdAsync(employeeId);
        }

        /// <summary>
        /// Обработчик события создания сотрудника
        /// </summary>
        private async void OnCreateEmployee(object sender, EmployeeDto employee)
        {
            try
            {
                _view.SetBusy(true);

                var request = new CreateEmployeeReq
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PatronymicName = employee.PatronymicName,
                    PassportNumber = employee.PassportNumber,
                    Department = employee.Department,
                    Position = employee.Position,
                    Photo = employee.Photo
                };

                var createdEmployee = await _employeeService.CreateEmployeeAsync(request);
                _view.ShowInfo($"Сотрудник {createdEmployee.LastName} {createdEmployee.FirstName} успешно добавлен");

                // Обновляем список сотрудников
                await LoadEmployeesAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка создания сотрудника: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события обновления данных сотрудника
        /// </summary>
        private async void OnUpdateEmployee(object sender, EmployeeDto employee)
        {
            try
            {
                _view.SetBusy(true);

                var request = new UpdateEmployeeReq
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PatronymicName = employee.PatronymicName,
                    Department = employee.Department,
                    Position = employee.Position,
                    Photo = employee.Photo,
                    IsActive = employee.IsActive
                };

                await _employeeService.UpdateEmployeeAsync(request);
                _view.ShowInfo($"Данные сотрудника {employee.LastName} {employee.FirstName} успешно обновлены");

                // Обновляем список сотрудников
                await LoadEmployeesAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка обновления данных сотрудника: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события удаления сотрудника
        /// </summary>
        private async void OnDeleteEmployee(object sender, int employeeId)
        {
            try
            {
                _view.SetBusy(true);
                await _employeeService.DeleteEmployeeAsync(employeeId);
                _view.ShowInfo("Сотрудник успешно удален");

                // Обновляем список сотрудников
                await LoadEmployeesAsync();

                // Очищаем форму
                _view.ClearForm();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка удаления сотрудника: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события привязки карты к сотруднику
        /// </summary>
        private async void OnAssignCardToEmployee(object sender, int employeeId)
        {
            // Здесь обычно должен быть вызов формы считывателя карты
            // В методе OnCardInfoReceived будет вызван после считывания карты
        }

        /// <summary>
        /// Обработчик события удаления карты у сотрудника
        /// </summary>
        private async void OnDeleteCardFromEmployee(object sender, int cardId)
        {
            try
            {
                _view.SetBusy(true);
                await _employeeService.DeleteCardAsync(cardId);
                _view.ShowInfo("Карта успешно удалена");

                // Обновляем список карт сотрудника
                if (_currentEmployee != null)
                {
                    _currentCards = new List<CardDto>(await _employeeService.GetEmployeeCardsAsync(_currentEmployee.Id));
                    _view.ShowEmployeeCards(_currentCards);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка удаления карты: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события получения информации о карте
        /// </summary>
        private async void OnCardInfoReceived(object sender, CardReadEventArgs e)
        {
            if (_currentEmployee == null)
            {
                _view.ShowError("Не выбран сотрудник для привязки карты");
                return;
            }

            try
            {
                _view.SetBusy(true);

                var request = new CreateCardReq
                {
                    EmployeeId = _currentEmployee.Id,
                    Hash = e.CardHash,
                    MaskPan = e.MaskPan
                };

                var createdCard = await _employeeService.CreateCardAsync(request);
                _view.ShowInfo("Карта успешно привязана к сотруднику");

                // Обновляем список карт сотрудника
                _currentCards = new List<CardDto>(await _employeeService.GetEmployeeCardsAsync(_currentEmployee.Id));
                _view.ShowEmployeeCards(_currentCards);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка привязки карты: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события активации карты
        /// </summary>
        private async void OnActivateCard(object sender, int cardId)
        {
            try
            {
                _view.SetBusy(true);
                await _employeeService.ActivateCardAsync(cardId);
                _view.ShowInfo("Карта успешно активирована");

                // Обновляем список карт сотрудника
                if (_currentEmployee != null)
                {
                    _currentCards = new List<CardDto>(await _employeeService.GetEmployeeCardsAsync(_currentEmployee.Id));
                    _view.ShowEmployeeCards(_currentCards);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка активации карты: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Обработчик события деактивации карты
        /// </summary>
        private async void OnDeactivateCard(object sender, int cardId)
        {
            try
            {
                _view.SetBusy(true);
                await _employeeService.DeactivateCardAsync(cardId);
                _view.ShowInfo("Карта успешно деактивирована");

                // Обновляем список карт сотрудника
                if (_currentEmployee != null)
                {
                    _currentCards = new List<CardDto>(await _employeeService.GetEmployeeCardsAsync(_currentEmployee.Id));
                    _view.ShowEmployeeCards(_currentCards);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка деактивации карты: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
    }
}