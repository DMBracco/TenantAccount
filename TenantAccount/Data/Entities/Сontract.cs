using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TenantAccount.Data.Entities
{
    public class Сontract
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public string? Number { get; set; }

        [Display(Name = "Наименование")]
        public string? Name { get; set; }

        [Display(Name = "Дата подписания")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Тип корреспондента")]
        public string? TypeCorrespondent { get; set; }

        [Display(Name = "Наименование корреспондента")]
        public string? NameCorrespondent { get; set; }

        [Display(Name = "ФИО представителя")]
        public string? RepresentativeFullName { get; set; }

        [Display(Name = "Должность представителя")]
        public string? RepresentativePost { get; set; }

        [Display(Name = "Тип договора")]
        public string? ContractType { get; set; }

        [Display(Name = "Объект договора")]
        public string? ContractObject { get; set; }

        [Display(Name = "Адрес объекта")]
        public string? ObjectAddress { get; set; }

        [Display(Name = "Используемая площадь")]
        public string? AreaUsed { get; set; }

        [Display(Name = "Сумма по договору ")]
        public float Amount { get; set; }

        [Display(Name = "Способ заключения")]
        public string? ConclusionMethod { get; set; }

        [Display(Name = "Периодичность начисления платы")]
        public string? PaymentPeriod { get; set; }

        [Display(Name = "Дата действия")]
        [DataType(DataType.Date)]
        public DateTime ValidityDate { get; set; }

        [Display(Name = "Дата расторжения")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Задолженность на дату по основному долгу")]
        public string? Arrears { get; set; }

        [Display(Name = "Задолженность на дату по процентам")]
        public string? ArrearsInterest { get; set; }

        [Display(Name = "Пени")]
        public string? Penalties { get; set; }

        [Display(Name = "Следующий платеж")]
        public string? NextPayment { get; set; }

        [Display(Name = "Существующие льготы")]
        public string? ExistingBenefits { get; set; }

        [Display(Name = "Существующие отсрочки ")]
        public string? ExistingDeferrals { get; set; }

        [Display(Name = "Статус")]
        public int StatusId { get; set; }
        [Display(Name = "Статус")]
        public СontractStatus? Status { get; set; }

        public IdentityUser? IdentityUser { get; set; }

        //[Display(Name = "Арендатор")]
        //public int TenantId { get; set; }
        //[Display(Name = "Арендатор")]
        //public Tenant? Tenant { get; set; }
    }
}
