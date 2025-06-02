using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Identity
{
    /// <summary>
    /// Класс для хранения запроса на обновление пользователя
    /// </summary>
    public class UpdateUserReq
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
