using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuickStart.Shared.Model
{
    public enum AgeGroup
    {
        [Description("Entre 18 e 20 anos")]
        Between18And20 = 1,
        [Description("Entre 21 e 25 anos")]
        Between21And25 = 2,
        [Description("Entre 26 e 30 anos")]
        Between26And30 = 3,
        [Description("Entre 31 e 39 anos")]
        Between31And39 = 4,
        [Description("Entre 40 e 49 anos")]
        Between40And49 = 5,
        [Description("Mais de 50 anos")]
        MoreThan50 = 6
    }
}
