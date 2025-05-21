using System;
using System.Collections.Generic;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления группами доступа
    /// </summary>
    public interface IAccessGroupView
    {
        /// <summary>
        /// Обновить список групп доступа
        /// </summary>
        void UpdateAccessGroupList(IEnumerable<AccessGroupDto> accessGroups);

        /// <summary>
        /// Отобразить детальную информацию о группе доступа
        /// </summary>
        void ShowAccessGroupDetails(AccessGroupDto accessGroup);

        /// <summary>
        /// Отобразить список сотрудников в группе доступа
        /// </summary>
        void ShowEmployeesInGroup(IEnumerable<EmployeeDto> employees);

        /// <summary>
        /// Отобразить сообщение об ошибке
        /// </summary>
        void ShowError(string message);

        /// <summary>
        /// Отобразить информацию
        /// </summary>
        void ShowInfo(string message);

        /// <summary>
        /// Установить состояние загрузки
        /// </summary>
        void SetBusy(bool isBusy);

        /// <summary>
        /// Очистить форму
        /// </summary>
        void ClearForm();

        /// <summary>
        /// Событие, когда выбрана группа доступа
        /// </summary>
        event EventHandler<int> AccessGroupSelected;

        /// <summary>
        /// Событие создания новой группы доступа
        /// </summary>
        event EventHandler<AccessGroupDto> CreateAccessGroup;

        /// <summary>
        /// Событие обновления данных группы доступа
        /// </summary>
        event EventHandler<AccessGroupDto> UpdateAccessGroup;

        /// <summary>
        /// Событие удаления группы доступа
        /// </summary>
        event EventHandler<int> DeleteAccessGroup;

        /// <summary>
        /// Событие добавления сотрудника в группу доступа
        /// </summary>
        event EventHandler<Tuple<int, int>> AddEmployeeToGroup;

        /// <summary>
        /// Событие удаления сотрудника из группы доступа
        /// </summary>
        event EventHandler<Tuple<int, int>> RemoveEmployeeFromGroup;
    }
} 