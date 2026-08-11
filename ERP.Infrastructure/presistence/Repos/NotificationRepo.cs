using ERP.Core.Entities;
using ERP.Core.EntityParams.notificationParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.Models.NotificationModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<NotificationRepo> _Logger;
        public NotificationRepo(AppDbContext context, ILogger<NotificationRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddNotificationParams Params)
        {
            try
            {
                Notification notification = new()
                {
                    Type = Params.Type,
                    Priority = Params.Priority,
                    Title = Params.Title,
                    Message = Params.Message,
                    RelatedEntityType = Params.RelatedEntityType,
                    RelatedEntityId = Params.RelatedEntityId,
                    TargetUserId = Params.TargetUserId,
                    CreatedAt = DateTime.UtcNow
                };
                _Context.Notifications.Add(notification);
                await _Context.SaveChangesAsync();
                return notification.Id;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Notification");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Notification? notification = await _Context.Notifications.FindAsync(Id);
                if (notification == null) return Errors.NotificationNotFound;
                _Context.Notifications.Remove(notification);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<NotificationDTO>> GetById(int Id)
        {
            try
            {
                NotificationDTO? notification = await _Context.Notifications.AsNoTracking()
                    .Where(n => n.Id == Id)
                    .Select(n => new NotificationDTO()
                    {
                        Id = n.Id,
                        Type = n.Type,
                        Priority = n.Priority,
                        Title = n.Title,
                        Message = n.Message,
                        RelatedEntityType = n.RelatedEntityType,
                        RelatedEntityId = n.RelatedEntityId,
                        TargetUserId = n.TargetUserId,
                        IsRead = n.IsRead,
                        ReadAt = n.ReadAt,
                        CreatedAt = n.CreatedAt
                    })
                    .SingleOrDefaultAsync();

                if (notification == null) return Errors.NotificationNotFound;
                return notification;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<NotificationDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Notification> query = _Context.Notifications.AsNoTracking()
                    .Where(n =>
                        (Params.TargetUserId == null || n.TargetUserId == Params.TargetUserId)
                        && (Params.Type == null || n.Type == Params.Type)
                        && (Params.IsRead == null || n.IsRead == Params.IsRead));

                int count = await query.CountAsync();

                List<NotificationDTO> notifications = await query
                    .OrderByDescending(n => n.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(n => new NotificationDTO()
                    {
                        Id = n.Id,
                        Type = n.Type,
                        Priority = n.Priority,
                        Title = n.Title,
                        Message = n.Message,
                        RelatedEntityType = n.RelatedEntityType,
                        RelatedEntityId = n.RelatedEntityId,
                        TargetUserId = n.TargetUserId,
                        IsRead = n.IsRead,
                        ReadAt = n.ReadAt,
                        CreatedAt = n.CreatedAt
                    })
                    .ToListAsync();

                return new PagedResult<NotificationDTO>()
                {
                    Items = notifications,
                    PageNumber = Params.PageNumber,
                    PageSize = Params.PageSize,
                    TotalCount = count
                };
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(int Id, UpdateNotificationParams Params)
        {
            try
            {
                Notification? notification = await _Context.Notifications.FindAsync(Id);
                if (notification == null) return Errors.NotificationNotFound;
                notification.IsRead = Params.IsRead;
                if (Params.ReadAt.HasValue) notification.ReadAt = Params.ReadAt;
                _Context.Notifications.Update(notification);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<HashSet<int>>> GetAlreadyNotifiedEntityIds(enNotificationType type, string relatedEntityType, DateTime since)
        {
            try
            {
                var ids = await _Context.Notifications
                    .AsNoTracking()
                    .Where(n => n.Type == type
                                && n.RelatedEntityType == relatedEntityType
                                && n.CreatedAt >= since
                                && n.RelatedEntityId.HasValue)
                    .Select(n => n.RelatedEntityId!.Value)
                    .ToListAsync();

                return new HashSet<int>(ids);
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error in GetAlreadyNotifiedEntityIds: {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<List<NotificationDTO>>> AddBatch(List<AddNotificationParams> paramsList)
        {
            try
            {
                var notifications = paramsList.Select(p => new Notification
                {
                    Type = p.Type,
                    Priority = p.Priority,
                    Title = p.Title,
                    Message = p.Message,
                    RelatedEntityType = p.RelatedEntityType,
                    RelatedEntityId = p.RelatedEntityId,
                    TargetUserId = p.TargetUserId,
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                }).ToList();

                _Context.Notifications.AddRange(notifications);
                await _Context.SaveChangesAsync();

                var dtos = notifications.Select(n => new NotificationDTO
                {
                    Id = n.Id,
                    Type = n.Type,
                    Priority = n.Priority,
                    Title = n.Title,
                    Message = n.Message,
                    RelatedEntityType = n.RelatedEntityType,
                    RelatedEntityId = n.RelatedEntityId,
                    TargetUserId = n.TargetUserId,
                    CreatedAt = n.CreatedAt,
                    IsRead = n.IsRead
                }).ToList();

                return dtos;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error in AddBatch: {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
