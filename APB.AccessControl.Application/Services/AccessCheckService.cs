using APB.AccessControl.Application.Services.Interfaces;
using APB.AccessControl.Shared.Models.Requests;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System;
using APB.AccessControl.Shared.Models.Responses;
using System.Collections.Generic;
using System.Linq;

namespace APB.AccessControl.Application.Services
{
    public class AccessCheckService: IAccessCheckService
    {
        private readonly ICardService _cardService;
        private readonly IAccessRuleService _accessRuleService;
        private readonly IAccessGroupService _accessGroupService;
        private readonly IAccessLogService _accessLogService;

        public AccessCheckService(IAccessRuleService accessRuleService,
                                  ICardService cardService,
                                  IAccessGroupService accessGroupService,
                                  IAccessLogService accessLogService)
        {
            _accessRuleService = accessRuleService;
            _cardService = cardService;
            _accessGroupService = accessGroupService;
            _accessLogService = accessLogService;
        }

        public async Task<AccessCheckResponse> CheckAccessAsync(CheckAccessReq request, CancellationToken cancellationToken = default)
        {
            try
            {
                //проверка есть ли такая карта и активна ли она
                var card = await _cardService.GetCardByHashAsync(request.CardHash);

                if (card is null || !card.IsActive)
                {
                    return new AccessCheckResponse()
                    {
                        IsSuccess = false,
                        Message = $"Card {request.CardHash} not found"
                    };

                }

                //получить группу сотрудника
                List<int> groupIdList = (await _accessGroupService.GetGroupIdByEmployeeId(card.EmployeeId)).ToList();

                if (groupIdList is null || groupIdList.Count == 0)
                {
                    return new AccessCheckResponse()
                    {
                        IsSuccess = false,
                        Message = $"Access denied"
                    };
                }

                //проверить все группы сотрудника на доступ к точке 
                foreach (var groupId in groupIdList)
                {
                    if (await _accessRuleService.CheckAccessByGroupIdAsync(groupId))
                    {
                        return new AccessCheckResponse()
                        { IsSuccess = true };

                    }
                }

                return new AccessCheckResponse()
                {
                    IsSuccess = false,
                    Message = $"Access denied"
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
