namespace HelloSunshineSMSSYNRN_API.Models
{
    public class SunshineMobileSms_202604
    {
        public string SMS_FROM_MOBILE { get; set; } = string.Empty;
        public string SMS_TEXT { get; set; } = string.Empty;
        public int SMS_ID { get; set; }
        public string SMS_DEVICE_DATE { get; set; } = string.Empty;
        public string READ_FLAG { get; set; } = "AUTO";
        public string LICENCE_NO { get; set; } = "2026";
        public string APP_VERSION { get; set; } = "2";
    }

    // We still need a tiny response object just so React Native knows if it worked
    public class SyncResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}