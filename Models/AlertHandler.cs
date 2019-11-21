namespace TradeHelper.Models
{
    public class AlertFactory
    {
        public bool? IsSuccess { get; set; }
        public string AlertFormat
        {
            get
            {
                return (bool)IsSuccess ? "alert-success" : "alert-danger";
            }
        }

        public string AlertText { get; set; }
    }
}
