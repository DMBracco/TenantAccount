using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TenantAccount.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Display(Name = "Тема")]
        public string? Title { get; set; }
        [Display(Name = "Сообщение")]
        public string? Text { get; set; }
        [Display(Name = "Прочитано")]
        public int Read { get; set; }
        [Display(Name = "Получатель")]
        public IdentityUser? IdentityUser { get; set; }
    }
}
