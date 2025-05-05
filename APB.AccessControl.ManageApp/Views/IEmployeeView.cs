using System;
using System.Collections.Generic;
using APB.AccessControl.ManageApp.Controls;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления сотрудниками
    /// </summary>
    public interface IEmployeeView
    {
        /// <summary>
        /// Обновить список сотрудников
        /// </summary>
        void UpdateEmployeeList(IEnumerable<EmployeeDto> employees);

        /// <summary>
        /// Отобразить детальную информацию о сотруднике
        /// </summary>
        void ShowEmployeeDetails(EmployeeDto employee);

        /// <summary>
        /// Отобразить список карт сотрудника
        /// </summary>
        void ShowEmployeeCards(IEnumerable<CardDto> cards);

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
        /// Событие, когда выбран сотрудник
        /// </summary>
        event EventHandler<int> EmployeeSelected;

        /// <summary>
        /// Событие создания нового сотрудника
        /// </summary>
        event EventHandler<EmployeeDto> CreateEmployee;

        /// <summary>
        /// Событие обновления данных сотрудника
        /// </summary>
        event EventHandler<EmployeeDto> UpdateEmployee;

        /// <summary>
        /// Событие удаления сотрудника
        /// </summary>
        event EventHandler<int> DeleteEmployee;

        /// <summary>
        /// Событие привязки карты к сотруднику
        /// </summary>
        event EventHandler<int> AssignCardToEmployee;

        /// <summary>
        /// Событие удаления карты у сотрудника
        /// </summary>
        event EventHandler<int> DeleteCardFromEmployee;

        /// <summary>
        /// Событие получения информации о карте
        /// </summary>
        event EventHandler<CardReadEventArgs> CardInfoReceived;
    }
}