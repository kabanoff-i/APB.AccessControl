using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;

namespace APB.AccessControl.ManageApp.Views
{
    /// <summary>
    /// Интерфейс представления для управления правилами доступа сотрудников
    /// </summary>
    public interface IAccessRuleView
    {
        /// <summary>
        /// Событие создания нового правила доступа
        /// </summary>
        event EventHandler CreateRule;
        
        /// <summary>
        /// Событие редактирования правила доступа
        /// </summary>
        event EventHandler<int> EditRule;
        
        /// <summary>
        /// Событие удаления правила доступа
        /// </summary>
        event EventHandler<int> DeleteRule;
        
        /// <summary>
        /// Событие копирования правила доступа
        /// </summary>
        event EventHandler<int> CopyRule;
        
        /// <summary>
        /// Событие обновления данных
        /// </summary>
        event EventHandler RefreshData;
        
        /// <summary>
        /// Установить список правил доступа в представление
        /// </summary>
        void SetAccessRules(IEnumerable<AccessRuleDto> rules);
        
        /// <summary>
        /// Установить список групп доступа для выбора
        /// </summary>
        void SetAccessGroups(IEnumerable<AccessGroupDto> groups);
        
        /// <summary>
        /// Установить список точек доступа для выбора
        /// </summary>
        void SetAccessPoints(IEnumerable<AccessPointDto> points);
        
        /// <summary>
        /// Получить выбранный идентификатор правила доступа
        /// </summary>
        int GetSelectedRuleId();
        
        /// <summary>
        /// Отобразить сообщение пользователю
        /// </summary>
        void ShowMessage(string message);
        
        /// <summary>
        /// Отобразить сообщение об ошибке
        /// </summary>
        void ShowError(string message);
        
        /// <summary>
        /// Очистить выбор
        /// </summary>
        void ClearSelection();
    }
} 