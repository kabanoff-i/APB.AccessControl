using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using APB.AccessControl.ClientApp.Config;
using APB.AccessControl.ClientApp.Services;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.ClientApp
{
    public partial class LoginForm : XtraForm
    {
        private readonly ApiService _apiService;
        private readonly AppConfig _config;
        private string _authToken;
        private DateTime _tokenExpiry;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _config = AppConfig.Load();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!_config.IsConfigured)
            {
                // Если конфигурации нет, показываем панель выбора точки доступа
                panelLogin.Visible = false;
                panelAccessPoint.Visible = true;
                labelTitle.Text = "Выберите точку доступа";
                buttonSave.Text = "Сохранить";
                LoadAccessPoints();
            }
            else
            {
                // Если конфигурация есть, показываем форму входа
                panelLogin.Visible = true;
                panelAccessPoint.Visible = false;
                labelTitle.Text = "Вход в систему";
                buttonSave.Text = "Войти";
            }
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (panelAccessPoint.Visible)
            {
                return; // Если видна панель выбора точки доступа, обработка будет в SaveAccessPoint_Click
            }

            if (string.IsNullOrEmpty(textEditUsername.Text) || string.IsNullOrEmpty(textEditPassword.Text))
            {
                XtraMessageBox.Show(
                    "Введите имя пользователя и пароль",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                buttonSave.Enabled = false;
                var loginResult = await _apiService.LoginAsync(textEditUsername.Text, textEditPassword.Text);

                if (!loginResult.IsSuccess)
                {
                    XtraMessageBox.Show(
                        loginResult.ErrorMessage,
                        "Ошибка авторизации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    buttonSave.Enabled = true;
                    return;
                }

                _authToken = loginResult.Token;
                _tokenExpiry = loginResult.ExpiresAt;

                if (!_config.IsConfigured)
                {
                    // Показываем панель выбора точки доступа
                    panelLogin.Visible = false;
                    panelAccessPoint.Visible = true;
                    labelTitle.Text = "Выберите точку доступа";
                    buttonSave.Text = "Сохранить";
                    LoadAccessPoints();
                }
                else
                {
                    // Сохраняем токен и закрываем форму
                    _config.Username = textEditUsername.Text;
                    _config.AuthToken = _authToken;
                    _config.TokenExpiry = _tokenExpiry;
                    _config.Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Ошибка авторизации: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                buttonSave.Enabled = true;
            }
        }

        private void SaveAccessPoint_Click(object sender, EventArgs e)
        {
            if (!panelAccessPoint.Visible)
            {
                return; // Если не видна панель выбора точки доступа, обработка будет в ButtonSave_Click
            }

            SaveAccessPoint();
        }

        private async void LoadAccessPoints()
        {
            try
            {
                var accessPoints = await _apiService.GetAccessPoints();
                comboBoxAccessPoints.Properties.Items.Clear();
                comboBoxAccessPoints.Properties.Items.AddRange(accessPoints);
                comboBoxAccessPoints.Enabled = true;
                buttonSave.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Ошибка загрузки списка точек доступа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SaveAccessPoint()
        {
            if (comboBoxAccessPoints.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "Выберите точку доступа",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                var selectedPoint = (AccessPointDto)comboBoxAccessPoints.SelectedItem;
                _config.AccessPointId = selectedPoint.Id;
                _config.AccessPointName = selectedPoint.Name;
                _config.IsConfigured = true;
                _config.Username = textEditUsername.Text;
                _config.AuthToken = _authToken;
                _config.TokenExpiry = _tokenExpiry;

                _config.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Ошибка сохранения конфигурации: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
} 