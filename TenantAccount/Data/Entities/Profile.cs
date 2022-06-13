using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TenantAccount.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        [Display(Name = "Тип корреспондента")]
        public string? Type { get; set; }

        [Display(Name = "ИНН")]
        public string? Inn { get; set; }

        [Display(Name = "КПП")]
        public string? Kpp { get; set; }

        [Display(Name = "Краткое наименование")]
        public string? ShortName { get; set; }

        [Display(Name = "Полное наименование")]
        public string? FullName { get; set; }

        [Display(Name = "Адрес юридический")]
        public string? LegalAddress { get; set; }

        [Display(Name = "Адрес фактический")]
        public string? ActualAddress { get; set; }

        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        [Display(Name = "Email")]
        public string? Emai { get; set; }

        [Display(Name = "Должность руководителя")]
        public string? HeadPosition { get; set; }

        [Display(Name = "ФИО руководителя")]
        public string? ManagerFullName { get; set; }

        [Display(Name = "Банковские реквизиты")]
        public string? BankDetails { get; set; }

        [Display(Name = "Документ удостоверения личности")]
        public string? IdentificationDocument { get; set; }

        public IdentityUser? IdentityUser { get; set; }
    }
}
