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

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _config = AppConfig.Load();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (_config.IsConfigured)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            LoadAccessPoints();
        }

        private async void LoadAccessPoints()
        {
            try
            {
                var accessPoints = await _apiService.GetAccessPoints();
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

        private async void ButtonSave_Click(object sender, EventArgs e)
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

                var selectedPoint = (AccessPointDto)comboBoxAccessPoints.SelectedItem;
                _config.AccessPointId = selectedPoint.Id;
                _config.AccessPointName = selectedPoint.Name;
                _config.IsConfigured = true;
                _config.Username = textEditUsername.Text;
                _config.AuthToken = loginResult.Token;
                _config.TokenExpiry = loginResult.ExpiresAt;

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
                buttonSave.Enabled = true;
            }
        }
    }

    public class AccessPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
} 