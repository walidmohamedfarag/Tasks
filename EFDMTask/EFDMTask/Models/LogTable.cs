using System;
using System.Collections.Generic;

namespace EFDMTask.Models;

public partial class LogTable
{
    public int LogId { get; set; }

    public string? Message { get; set; }

    public DateTime? DateOrder { get; set; }
}
