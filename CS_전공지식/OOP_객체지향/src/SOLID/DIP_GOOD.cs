interface ILogger
{
    public void logError(string message);
}

class DatabaseLogger : ILogger
{
    public void logError(string message)
    {
        // ..
    }
}

class MailerService
{
    private ILogger logger;

    public MailerService(ILogger logger)
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

/*
이러한 방식으로 세부 구현이 LoggerInterface 를 구현하는 한 
데이터베이스의 로그를 원하는 로그로 자유롭게 바꿀 수 있습니다 . 
이 변경 사항은 MailerService에 의존하지 않고 
인터페이스에만 의존하기 때문에
MailerService 를 수정할 필요가 없습니다 .
*/