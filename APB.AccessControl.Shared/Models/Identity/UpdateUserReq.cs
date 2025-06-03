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
        public string Id { get; set; }
        public List<string> Roles { get; set; }
    }
}
