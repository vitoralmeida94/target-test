using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Log
    {
        public long Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
}
