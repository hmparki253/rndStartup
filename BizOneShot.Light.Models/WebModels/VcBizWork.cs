// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;

namespace BizOneShot.Light.Models.WebModels
{
    // VC_BIZ_WORK
    public class VcBizWork
    {
        public int BizWorkSn { get; set; } // BIZ_WORK_SN
        public int CompSn { get; set; } // COMP_SN (Primary key)
        public DateTime? RegDt { get; set; } // REG_DT
        public DateTime? UpdDt { get; set; } // UPD_DT
    }

}
