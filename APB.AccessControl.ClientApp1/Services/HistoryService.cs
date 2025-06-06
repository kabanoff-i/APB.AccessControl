using APB.AccessControl.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APB.AccessControl.ClientApp.Services
{
    public class HistoryService
    {
        private readonly ApiService _apiService;
        private readonly List<AccessLogDto> _history;

        public HistoryService(ApiService apiService)
        {
            _apiService = apiService;
            _history = new List<AccessLogDto>();
        }

        public async Task LoadHistory(DateTime? fromDate = null, DateTime? toDate = null, string searchText = null)
        {
            var history = await _apiService.GetPassHistory(fromDate, toDate, searchText);
            _history.Clear();
            _history.AddRange(history);
            OnHistoryChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<AccessLogDto> GetHistory()
        {
            return _history;
        }

        public event EventHandler OnHistoryChanged;
    }
} 