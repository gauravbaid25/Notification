namespace NotificationService.Interface
{
    public interface ITransaction
    {
        ISender GetInstance();
    }
}
