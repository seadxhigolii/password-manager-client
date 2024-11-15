namespace password_manager_client.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly Action _next;

        public ExceptionMiddleware(Action next)
        {
            _next = next;
        }

        public void Invoke()
        {
            try
            {
                _next.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
