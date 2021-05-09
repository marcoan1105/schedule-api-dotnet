using System.Linq;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Schedule.Domain.Abstractions;
using Schedule.Domain.Notification;

namespace Schedule.Api.Application.Abstractions
{
    public class ControllerAbstraction : ControllerBase
    {
        protected IMapper Mapper;
        protected INotificationHandler NotificationHandler;
        public ControllerAbstraction(IMapper mapper, INotificationHandler notificationHandler)
        {
            Mapper = mapper;
            NotificationHandler = notificationHandler;
        }

        [NonAction]
        public IActionResult CreateResponseOk(object obj){

            if(NotificationHandler.HasError()){
                return BadRequest(NotificationHandler.GetErrorResponse());
            }else{
                return Ok(obj);
            }
        }
    }
}