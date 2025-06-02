using System;
using System.Collections.Generic;

namespace APB.AccessControl.Shared.Models.DTOs
{
    /// <summary>
    /// DTO для передачи данных о пользователе
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; }
    }
} 