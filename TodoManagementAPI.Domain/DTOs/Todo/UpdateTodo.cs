﻿namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class UpdateTodoDto : TodoDto 
    {
        public Guid TodoId { get; set; }
    }
}
