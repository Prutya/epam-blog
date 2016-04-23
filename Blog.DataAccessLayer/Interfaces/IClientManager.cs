using Blog.DataAccessLayer.Models;
using System;

namespace Blog.DataAccessLayer.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        ClientProfile Get(string id);
    }
}
