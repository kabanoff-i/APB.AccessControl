using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using APB.AccessControl.Shared.Models.DTOs;

namespace APB.AccessControl.ManageApp.Forms
{
    public partial class EmployeeAccessGroupForm : XtraForm
    {
        private readonly List<EmployeeDto> _availableEmployees;
        private readonly List<EmployeeDto> _selectedEmployees;
        private readonly string _groupName;
        
        public List<EmployeeDto> SelectedEmployees => _selectedEmployees;
        
        public EmployeeAccessGroupForm(string groupName, IEnumerable<EmployeeDto> allEmployees, IEnumerable<EmployeeDto> currentEmployees)
        {
            InitializeComponent();
            
            _groupName = groupName;
            _availableEmployees = allEmployees.Except(currentEmployees, new EmployeeDtoComparer()).ToList();
            _selectedEmployees = currentEmployees.ToList();
            
            Text = $"Управление сотрудниками группы \"{_groupName}\"";
            
            InitializeGrids();
            UpdateGrids();
        }
        
        private void InitializeGrids()
        {
            // Настройка грида доступных сотрудников
            gridViewAvailable.OptionsSelection.MultiSelect = true;
            gridViewAvailable.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridViewAvailable.OptionsView.ShowGroupPanel = false;
            gridViewAvailable.OptionsCustomization.AllowColumnMoving = false;
            
            // Настройка грида выбранных сотрудников
            gridViewSelected.OptionsSelection.MultiSelect = true;
            gridViewSelected.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridViewSelected.OptionsView.ShowGroupPanel = false;
            gridViewSelected.OptionsCustomization.AllowColumnMoving = false;
            
            
        }
        
        private void ConfigureColumns(GridView gridView)
        {
            if (gridView.Columns["Photo"] != null)
            {
                gridView.Columns["Photo"].Visible = false;
            }
            if (gridView.Columns["PassportNumber"] != null)
            {
                gridView.Columns["PassportNumber"].Visible = false;
            }
            if (gridView.Columns["Id"] != null)
            {
                gridView.Columns["Id"].Visible = false;
            }

            //gridView.Columns.Clear();

            //gridView.Columns.AddField("Id").Visible = false;

            //var colLastName = gridView.Columns.AddField("LastName");
            //colLastName.Caption = "Фамилия";
            //colLastName.VisibleIndex = 0;

            //var colFirstName = gridView.Columns.AddField("FirstName");
            //colFirstName.Caption = "Имя";
            //colFirstName.VisibleIndex = 1;

            //var colMiddleName = gridView.Columns.AddField("PatronymicName");
            //colMiddleName.Caption = "Отчество";
            //colMiddleName.VisibleIndex = 2;

            //var colPosition = gridView.Columns.AddField("Position");
            //colPosition.Caption = "Должность";
            //colPosition.VisibleIndex = 3;

            gridView.BestFitColumns();
        }
        
        private void UpdateGrids()
        {
            gridControlAvailable.DataSource = null;
            gridControlAvailable.DataSource = _availableEmployees;
            
            gridControlSelected.DataSource = null;
            gridControlSelected.DataSource = _selectedEmployees;
            
            gridViewAvailable.BestFitColumns();
            gridViewSelected.BestFitColumns();

            // Настройка колонок
            ConfigureColumns(gridViewAvailable);
            ConfigureColumns(gridViewSelected);

            UpdateButtonStates();
        }
        
        private void UpdateButtonStates()
        {
            btnMoveToSelected.Enabled = gridViewAvailable.GetSelectedRows().Length > 0;
            btnMoveToAvailable.Enabled = gridViewSelected.GetSelectedRows().Length > 0;
            btnMoveAllToSelected.Enabled = _availableEmployees.Count > 0;
            btnMoveAllToAvailable.Enabled = _selectedEmployees.Count > 0;
        }
        
        private void MoveSelectedEmployees(GridView sourceView, List<EmployeeDto> sourceList, List<EmployeeDto> targetList)
        {
            var selectedRows = sourceView.GetSelectedRows();
            var employeesToMove = selectedRows.Select(row => sourceView.GetRow(row) as EmployeeDto).ToList();
            
            foreach (var employee in employeesToMove)
            {
                if (employee != null)
                {
                    sourceList.Remove(employee);
                    targetList.Add(employee);
                }
            }
            
            UpdateGrids();
        }
        
        private void MoveAllEmployees(List<EmployeeDto> sourceList, List<EmployeeDto> targetList)
        {
            targetList.AddRange(sourceList);
            sourceList.Clear();
            UpdateGrids();
        }
        
        private void btnMoveToSelected_Click(object sender, EventArgs e)
        {
            MoveSelectedEmployees(gridViewAvailable, _availableEmployees, _selectedEmployees);
        }
        
        private void btnMoveToAvailable_Click(object sender, EventArgs e)
        {
            MoveSelectedEmployees(gridViewSelected, _selectedEmployees, _availableEmployees);
        }
        
        private void btnMoveAllToSelected_Click(object sender, EventArgs e)
        {
            MoveAllEmployees(_availableEmployees, _selectedEmployees);
        }
        
        private void btnMoveAllToAvailable_Click(object sender, EventArgs e)
        {
            MoveAllEmployees(_selectedEmployees, _availableEmployees);
        }
        
        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            UpdateButtonStates();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
    
    public class EmployeeDtoComparer : IEqualityComparer<EmployeeDto>
    {
        public bool Equals(EmployeeDto x, EmployeeDto y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Id == y.Id;
        }
        
        public int GetHashCode(EmployeeDto obj)
        {
            return obj.Id.GetHashCode();
        }
    }
} 