﻿using ItVacancies.Models.Base;

namespace ItVacancies.Models
{
    public class Employer : BaseModel
    {
        public string Name { get; set; }
        public string Contacts {  get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
