using System;
using System.Collections.Generic;

namespace EFDMTask.Models;

public partial class Log
{
    public int LogId { get; set; }

    public string? Message { get; set; }

    public DateTime? DateTime { get; set; }
}
