using TodoApi.Models;

namespace TodoApi.Extensions
{
    public static class Extensions
    {
        public static TodoItemDTO ToDTO(this TodoItem todoItem) =>
           new TodoItemDTO
           {
               Id = todoItem.Id,
               Name = todoItem.Name,
               IsComplete = todoItem.IsComplete
           };

        // old school way
        public static TodoItemDTO ToDTO2(this TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }
    }
}
