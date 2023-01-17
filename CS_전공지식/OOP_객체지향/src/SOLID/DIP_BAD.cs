class DatabaseLogger
{
    public void logError(string message)
    {
        // ..
    }
}

class MailerService
{
    private DatabaseLogger logger;

    public MailerService(DatabaseLogger logger)
    {
        this.logger = logger;
    }

    public void sendEmail()
    {
        try {
            // ..
        } catch (SomeException exception) {
            this.logger.logError(exception.getMessage());
        }
    }
}