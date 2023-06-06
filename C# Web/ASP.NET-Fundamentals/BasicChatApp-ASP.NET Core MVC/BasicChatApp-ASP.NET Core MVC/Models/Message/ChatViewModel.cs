namespace BasicChatApp_ASP.NET_Core_MVC.Models.Message
{
    public class ChatViewModel
    {

        public MessageViewModel CurrentMessage { get; set; } = null!;
        public List<MessageViewModel> Messages { get; set; } = null!;
    }
}
