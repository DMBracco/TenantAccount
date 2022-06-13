using System.ComponentModel.DataAnnotations;

namespace TenantAccount.Data.Entities
{
    public class СontractStatus
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string? Name { get; set; }
    }
}
