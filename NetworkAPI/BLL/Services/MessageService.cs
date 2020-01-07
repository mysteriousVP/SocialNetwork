using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Configuration;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<MessageDTO> AddMessage(int userId, MessageToCreateDTO message)
        {
            User recipient = await unitOfWork.UserRepository.GetUser(message.RecipientId);

            if (recipient == null)
            {
                throw new ServicesException("Recipient does not exist. Try again.");
            }

            if (message.Content.Length > LengthRestrictions.MESSAGE_MAX_LENGTH)
            {
                message.Content = message.Content.Substring(0, LengthRestrictions.MESSAGE_MAX_LENGTH);
            }

            message.SenderId = userId;
            Message newMessage = mapper.Map<Message>(message);
            unitOfWork.MessageRepository.Add(newMessage);

            if (await unitOfWork.SaveChanges())
            {
                return mapper.Map<MessageDTO>(newMessage);
            }

            throw new ServicesException("Saving message is failed.");
        }

        public async Task<bool> DeleteMessage(int userId, int messageId)
        {
            Message message = await unitOfWork.MessageRepository.Get(messageId);

            if (message.RecipientId == userId)
            {
                message.RecipientDeleted = true;
            }

            if (message.SenderId == userId)
            {
                message.SenderDeleted = true;
            }

            if (message.RecipientDeleted == true && message.SenderDeleted == true)
            {
                unitOfWork.MessageRepository.Remove(message);
            }

            return await unitOfWork.SaveChanges();
        }

        public async Task<MessageDTO> GetMessage(int messageId)
        {
            Message message = await unitOfWork.MessageRepository.Get(messageId);

            return mapper.Map<MessageDTO>(message);
        }

        public async Task<IEnumerable<MessageDTO>> GetMessages(int userId, int companionId)
        {
            IEnumerable<Message> messages = await unitOfWork.MessageRepository.GetMessages(userId);

            messages = messages.Where(m => m.SenderId == userId && m.RecipientId == companionId
                                    || m.SenderId == companionId && m.RecipientId == userId)
                               .OrderByDescending(m => m.MessageSent);

            messages = messages.Where(m => m.SenderId == userId && m.SenderDeleted == false
                                    || m.RecipientId == userId && m.RecipientDeleted == false);

            foreach (Message message in messages)
            {
                if (message.RecipientId == userId && message.IsRead == false)
                {
                    await MarkAsRead(userId, message.Id);
                }
            }

            return mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task<bool> MarkAsRead(int userId, int messageId)
        {
            Message message = await unitOfWork.MessageRepository.Get(messageId);

            if (message.RecipientId != userId)
            {
                throw new ServicesException("It is not possible to mark not yours message as read.");
            }

            message.IsRead = true;
            message.DateRead = DateTime.Now;

            return await unitOfWork.SaveChanges();
        }
    }
}
