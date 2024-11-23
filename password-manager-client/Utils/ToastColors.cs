namespace password_manager_client.Utils
{
    public static class ToastColors
    {
        private static readonly Color DefaultBackgroundColor = Color.Gray;
        private static readonly Color DefaultTextColor = Color.White;

        public static Color GetBackgroundColor(string? messageType)
        {
            if (string.IsNullOrWhiteSpace(messageType))
                return DefaultBackgroundColor;

            return messageType.ToLower() switch
            {
                "success" => ColorTranslator.FromHtml("#017E45"),
                "error" => ColorTranslator.FromHtml("#B22234"),
                "info" => ColorTranslator.FromHtml("#0056A6"),
                "warning" => ColorTranslator.FromHtml("#FF8C00"),
                _ => DefaultBackgroundColor
            };
        }

        public static Color GetTextColor(string? messageType)
        {
            if (string.IsNullOrWhiteSpace(messageType))
                return DefaultTextColor;

            return messageType.ToLower() switch
            {
                "success" => Color.White,
                "error" => Color.White,
                "info" => Color.White,
                "warning" => Color.Black,
                _ => DefaultTextColor
            };
        }
    }
}
