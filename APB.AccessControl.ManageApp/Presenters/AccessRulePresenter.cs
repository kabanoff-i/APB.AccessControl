using APB.AccessControl.ManageApp.Forms;
using APB.AccessControl.ManageApp.Services;
using APB.AccessControl.ManageApp.Views;
using APB.AccessControl.Shared.Models.DTOs;
using APB.AccessControl.Shared.Models.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APB.AccessControl.ManageApp.Presenters
{
    /// <summary>
    /// Презентер для управления правилами доступа сотрудников
    /// </summary>
    public class AccessRulePresenter
    {
        private readonly IAccessRuleView _view;
        private readonly AccessRuleService _accessRuleService;
        private readonly AccessGroupService _accessGroupService;
        private readonly AccessPointService _accessPointService;

        private IEnumerable<AccessRuleDto> _accessRules;
        private IEnumerable<AccessGroupDto> _accessGroups;
        private IEnumerable<AccessPointDto> _accessPoints;
        private int? _selectedRuleId;

        /// <summary>
        /// Конструктор презентера
        /// </summary>
        public AccessRulePresenter(
            IAccessRuleView view, 
            AccessRuleService accessRuleService,
            AccessGroupService accessGroupService,
            AccessPointService accessPointService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _accessRuleService = accessRuleService ?? throw new ArgumentNullException(nameof(accessRuleService));
            _accessGroupService = accessGroupService ?? throw new ArgumentNullException(nameof(accessGroupService));
            _accessPointService = accessPointService ?? throw new ArgumentNullException(nameof(accessPointService));

            // Подписка на события представления
            _view.CreateRule += async (sender, e) => await CreateRuleAsync();
            _view.EditRule += async (sender, e) => await EditRuleAsync(e);
            _view.DeleteRule += async (sender, e) => await DeleteRuleAsync(e);
            _view.CopyRule += async (sender, e) => await CopyRuleAsync(e);
            _view.RefreshData += async (sender, e) => await RefreshDataAsync();
        }

        /// <summary>
        /// Инициализация презентера
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                // Загружаем списки групп доступа и точек доступа
                await LoadAccessGroupsAsync();
                await LoadAccessPointsAsync();
                
                // Затем загружаем правила доступа
                await RefreshDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при инициализации: {ex.Message}");
            }
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            // Дополнительное освобождение ресурсов не требуется
        }

        /// <summary>
        /// Загрузка групп доступа
        /// </summary>
        private async Task LoadAccessGroupsAsync()
        {
            try
            {
                _accessGroups = await _accessGroupService.GetAccessGroupsAsync();
                _view.SetAccessGroups(_accessGroups);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке групп доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Загрузка точек доступа
        /// </summary>
        private async Task LoadAccessPointsAsync()
        {
            try
            {
                _accessPoints = await _accessPointService.GetAllAsync();
                _view.SetAccessPoints(_accessPoints);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при загрузке точек доступа: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Обновление данных
        /// </summary>
        private async Task RefreshDataAsync()
        {
            try
            {
                // Сохраняем текущий выбранный ID
                _selectedRuleId = _view.GetSelectedRuleId();

                // Получаем все правила через сервис
                _accessRules = await _accessRuleService.GetAllAsync();
                _view.SetAccessRules(_accessRules);

                // Восстанавливаем выбор, если он был
                if (_selectedRuleId.HasValue && _selectedRuleId > 0)
                {
                    // Проверяем, существует ли еще выбранное правило
                    var exists = _accessRules.Any(r => r.Id == _selectedRuleId.Value);
                    if (!exists)
                    {
                        _view.ClearSelection();
                        _selectedRuleId = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при получении данных: {ex.Message}");
            }
        }

        /// <summary>
        /// Создание нового правила доступа
        /// </summary>
        private async Task CreateRuleAsync()
        {
            try
            {
                // Открываем форму создания нового правила доступа
                using (var form = new AccessRuleEditForm(_accessGroups, _accessPoints))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Получаем запрос на создание из формы и отправляем через сервис
                        await _accessRuleService.CreateAsync(form.CreateRequest);
                        _view.ShowMessage("Правило доступа успешно создано");
                        await RefreshDataAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при создании правила доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Редактирование правила доступа
        /// </summary>
        private async Task EditRuleAsync(int ruleId)
        {
            try
            {
                // Получаем данные правила для редактирования
                var rule = _accessRules.FirstOrDefault(r => r.Id == ruleId);
                if (rule == null)
                {
                    _view.ShowError("Правило доступа не найдено");
                    return;
                }

                // Открываем форму редактирования
                using (var form = new AccessRuleEditForm(rule, _accessGroups, _accessPoints))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Получаем запрос на обновление из формы и отправляем через сервис
                        await _accessRuleService.UpdateAsync(form.UpdateRequest);
                        _view.ShowMessage("Правило доступа успешно обновлено");
                        await RefreshDataAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при редактировании правила доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаление правила доступа
        /// </summary>
        private async Task DeleteRuleAsync(int ruleId)
        {
            try
            {
                // Запрос подтверждения удаления
                if (MessageBox.Show("Вы действительно хотите удалить правило доступа?", "Подтверждение удаления", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                // Отправляем запрос через сервис
                await _accessRuleService.DeleteAsync(ruleId);
                _view.ShowMessage("Правило доступа успешно удалено");
                _view.ClearSelection();
                await RefreshDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при удалении правила доступа: {ex.Message}");
            }
        }

        /// <summary>
        /// Копирование правила доступа
        /// </summary>
        private async Task CopyRuleAsync(int ruleId)
        {
            try
            {
                // Получаем данные правила для копирования
                var rule = _accessRules.FirstOrDefault(r => r.Id == ruleId);
                if (rule == null)
                {
                    _view.ShowError("Правило доступа не найдено");
                    return;
                }

                // Создаем форму на основе данных существующего правила
                using (var form = new AccessRuleEditForm(rule, _accessGroups, _accessPoints))
                {
                    // Изменяем заголовок формы
                    form.Text = "Копирование правила доступа";
                    
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Используем запрос на создание из формы, так как это новое правило
                        await _accessRuleService.CreateAsync(form.CreateRequest);
                        _view.ShowMessage("Правило доступа успешно скопировано");
                        await RefreshDataAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка при копировании правила доступа: {ex.Message}");
            }
        }
    }
} 