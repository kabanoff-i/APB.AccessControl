using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для работы с представлением групп доступа (MVP паттерн)
    /// </summary>
    public class AccessGroupPresenter
    {
        private readonly IAccessGroupView _view;
        private readonly AccessGroupService _accessGroupService;
        
        private AccessGroupDto _currentAccessGroup;
        private List<EmployeeDto> _employeesInGroup;
        
        public AccessGroupPresenter(IAccessGroupView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            
            _accessGroupService = new AccessGroupService();
            
            // Подписываемся на события от представления
            _view.AccessGroupSelected += OnAccessGroupSelected;
            _view.CreateAccessGroup += OnCreateAccessGroup;
            _view.UpdateAccessGroup += OnUpdateAccessGroup;
            _view.DeleteAccessGroup += OnDeleteAccessGroup;
            _view.AddEmployeeToGroup += OnAddEmployeeToGroup;
            _view.RemoveEmployeeFromGroup += OnRemoveEmployeeFromGroup;
        }
        
        /// <summary>
        /// Загрузить список всех групп доступа
        /// </summary>
        public async Task LoadAccessGroupsAsync()
        {
            try
            {
                _view.SetBusy(true);
                var accessGroups = await _accessGroupService.GetAccessGroupsAsync();
                _view.UpdateAccessGroupList(accessGroups);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки списка групп доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Загрузить данные группы доступа по ID
        /// </summary>
        public async Task LoadAccessGroupByIdAsync(int accessGroupId)
        {
            try
            {
                _view.SetBusy(true);
                
                // Получаем детали группы доступа
                _currentAccessGroup = await _accessGroupService.GetAccessGroupByIdAsync(accessGroupId);
                _view.ShowAccessGroupDetails(_currentAccessGroup);
                
                // Загружаем сотрудников в группе
                await LoadEmployeesInGroupAsync(accessGroupId);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки данных группы доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Загрузить список сотрудников в группе доступа
        /// </summary>
        private async Task LoadEmployeesInGroupAsync(int accessGroupId)
        {
            try
            {
                var employees = await _accessGroupService.GetEmployeesInGroupAsync(accessGroupId);
                _employeesInGroup = new List<EmployeeDto>(employees);
                _view.ShowEmployeesInGroup(_employeesInGroup);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки списка сотрудников в группе: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обработчик события выбора группы доступа
        /// </summary>
        private async void OnAccessGroupSelected(object sender, int accessGroupId)
        {
            await LoadAccessGroupByIdAsync(accessGroupId);
        }
        
        /// <summary>
        /// Обработчик события создания группы доступа
        /// </summary>
        private async void OnCreateAccessGroup(object sender, AccessGroupDto accessGroup)
        {
            try
            {
                _view.SetBusy(true);
                
                await _accessGroupService.CreateAccessGroupAsync(accessGroup.Name);
                _view.ShowInfo($"Группа доступа \"{accessGroup.Name}\" успешно создана");
                await LoadAccessGroupsAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка создания группы доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Обработчик события обновления группы доступа
        /// </summary>
        private async void OnUpdateAccessGroup(object sender, AccessGroupDto accessGroup)
        {
            try
            {
                _view.SetBusy(true);


                await _accessGroupService.UpdateAccessGroupAsync(
                    accessGroup.Id,
                    accessGroup.Name,
                    accessGroup.IsActive);
                
                _view.ShowInfo($"Группа доступа \"{accessGroup.Name}\" успешно обновлена");
                await LoadAccessGroupsAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка обновления группы доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Обработчик события удаления группы доступа
        /// </summary>
        private async void OnDeleteAccessGroup(object sender, int accessGroupId)
        {
            try
            {
                _view.SetBusy(true);
                
                await _accessGroupService.DeleteAccessGroupAsync(accessGroupId);
                _view.ShowInfo("Группа доступа успешно удалена");
                await LoadAccessGroupsAsync();
                _view.ClearForm();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка удаления группы доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Обработчик события добавления сотрудника в группу доступа
        /// </summary>
        private async void OnAddEmployeeToGroup(object sender, Tuple<int, int> ids)
        {
            try
            {
                int employeeId = ids.Item1;
                int accessGroupId = ids.Item2;
                
                _view.SetBusy(true);
                
                await _accessGroupService.AddEmployeeToGroupAsync(employeeId, accessGroupId);
                _view.ShowInfo("Сотрудник успешно добавлен в группу доступа");
                
                // Обновляем список сотрудников в группе
                await LoadEmployeesInGroupAsync(accessGroupId);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка добавления сотрудника в группу доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }
        
        /// <summary>
        /// Обработчик события удаления сотрудника из группы доступа
        /// </summary>
        private async void OnRemoveEmployeeFromGroup(object sender, Tuple<int, int> ids)
        {
            try
            {
                int employeeId = ids.Item1;
                int accessGroupId = ids.Item2;
                
                _view.SetBusy(true);
                
                await _accessGroupService.RemoveEmployeeFromGroupAsync(employeeId, accessGroupId);
                _view.ShowInfo("Сотрудник успешно удален из группы доступа");
                
                // Обновляем список сотрудников в группе
                await LoadEmployeesInGroupAsync(accessGroupId);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка удаления сотрудника из группы доступа: {ex.Message}");
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        /// <summary>
        /// Получить список всех сотрудников
        /// </summary>
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            try
            {
                return await _accessGroupService.GetAllEmployeesAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки списка сотрудников: {ex.Message}");
                return new List<EmployeeDto>();
            }
        }
    }
} 