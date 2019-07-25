using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    /// <summary>
    /// The class responsible for holding general information of the application in the
    /// intent of having less hard-coded strings in views and this is essentially the
    /// same information describing the application across all platforms
    /// </summary>
    public static class ApplicationInformation
    {
        public const string ShortDescription = "Knowledge sharing web application where employees share their experience facing and dealing with technical issues.";

        public const string Credits = "Created by Hesham Medhat as part of the summer internship in summer 2019 at CivilSoft company's branch in Alexandria, Egypt.";

    }
}
