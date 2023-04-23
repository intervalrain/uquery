using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Reflection;
using System.ComponentModel;

namespace UQuery.Container
{
    public enum DatabaseIndex 
    {
        [DisplayName("Product")]
        PRODUCT,
        [DisplayName("Stage")]
        STAGE,
        [DisplayName("Step")]
        STEP,
        [DisplayName("Stepname")]
        STEPNAME,
        [DisplayName("Recipe")]
        RECIPE,
        [DisplayName("Lot")]
        LOT,
        [DisplayName("Wafer")]
        WAFER,
        [DisplayName("Processing Equipment")]
        PROCESS_EQ,
        [DisplayName("Measuring Equipment")]
        MEASURE_EQ,
        [Description("Technology")]
        TECHNOLOGY,
        [DisplayName("Parameter")]
        PARAMETER

    }
}