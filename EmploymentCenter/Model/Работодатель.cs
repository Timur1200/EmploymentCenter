//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmploymentCenter.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Работодатель
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Работодатель()
        {
            this.Вакансия = new HashSet<Вакансия>();
        }
    
        public int Код { get; set; }
        public string Фио { get; set; }
        public string Телефон { get; set; }
        public string Пароль { get; set; }
        public string НаименованиеКомпании { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Вакансия> Вакансия { get; set; }
    }
}
