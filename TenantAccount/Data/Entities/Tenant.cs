using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TenantAccount.Data.Entities
{
    public class Tenant
    {
        public int Id { get; set; }

        [Display(Name = "ИНН")]
        public string? Inn { get; set; }

        [Display(Name = "КПП")]
        public string? Kpp { get; set; }

        [Display(Name = "Имя организации")]
        public string? OrganizationName { get; set; }

        [Display(Name = "Адрес")]
        public string? Address { get; set; }

        public IdentityUser? IdentityUser { get; set; }

        [Display(Name = "Статус")]
        public int StatusId { get; set; }

        [Display(Name = "Статус")]
        public TenantStatus? Status { get; set; }

        public List<Сontract> Сontracts { get; set; } = new();
    }
}
