using InstaBot.Application.DTOs;
using System;

namespace InstaBot.ProducerAPI.DTOs
{
    public class NewPostResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}