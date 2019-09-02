using AutoMapper;
using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Dtos;
using FarmTradeApp.Helpers;
using FarmTradeApp.Core.Models.Notifications;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarmTradeApp.Controllers.api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userNotifications = unitOfWork.UserNotifications
                .GetUnreadUserNotifications(User.Identity.GetUserId());

            userNotifications.ToList().ForEach(n => n.Read());

            unitOfWork.Complete();

            return Ok();
        }

        //GET /api/notifications

        public IEnumerable<NotificationDto> GetNotifications()
        {
            return unitOfWork.Notifications
                .GetUnreadNotifications(User.Identity.GetUserId())
                .Select(Mapper.Map<Notification, NotificationDto>);     
        }

    }
}
