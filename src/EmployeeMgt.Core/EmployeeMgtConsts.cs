using EmployeeMgt.Debugging;

namespace EmployeeMgt
{
    public class EmployeeMgtConsts
    {
        public const string LocalizationSourceName = "EmployeeMgt";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8d0eb62b021b444cbccfe875fd499bf5";
    }
}
