using BasicChatApp_ASP.NET_Core_MVC.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace BasicChatApp_ASP.NET_Core_MVC.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> _messages = new List<KeyValuePair<string, string>>();


        public IActionResult Show()
        {
            if (_messages.Count == 0)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = _messages.Select(x => new MessageViewModel() {
                    Sender = x.Key,
                    MessageText = x.Value
                }).ToList()

            };

            return View(chatModel);
        }


        [HttpPost]
        public IActionResult SendMessage(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            _messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }

}
