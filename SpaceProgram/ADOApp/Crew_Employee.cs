//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaceProgram.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Crew_Employee
    {
        public int Crew_Employee_ID { get; set; }
        public int Crew_ID { get; set; }
        public int Employee_ID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Crew Crew { get; set; }
    }
}
