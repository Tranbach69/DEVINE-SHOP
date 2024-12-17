﻿using DevineShop.Core.Common;

namespace DevineShop.Core.Entities
{
    public class Contact:AuditableEntity
    {
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Email { get; set; }
        public string Zalo { get; set; }
    }
}
