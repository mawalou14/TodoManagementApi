﻿namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class TodoDto 
    {
        public string? Description { get; set; }
        public DateTime TargetedTime { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
    }
}
