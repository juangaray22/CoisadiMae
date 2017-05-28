using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using CoisadiMae.Infrastructure.Repositories;
using CoisadiMae.Models;
using CoisadiMae.Util;
using CoisadiMae.Util.ConnectivityFunctions;
using CoisadiMae.Util.Exceptions;
using Newtonsoft.Json;

namespace CoisadiMae.ApplicationServices
{
    /// <summary>
    /// ChatApplicationService application service.
    /// </summary>
    public class ChatApplicationService : IChatApplicationService
    {
        readonly IBaseRepository<Conversation> _repository;
        readonly IConnectivityFunctions _connectivity;

        public ChatApplicationService(IBaseRepository<Conversation> repository,
                                       IConnectivityFunctions connectivity)
        {
            App.AppBaseHttpClient = BaseHttpClient.Instance;

            _repository = repository;
            _connectivity = connectivity;
        }

        public void Add(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public Conversation Get(int pkId)
        {
            throw new NotImplementedException();
        }

        public List<Conversation> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Conversation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<Conversation> GetAllWithPredicate(Expression<Func<Conversation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Conversation>> GetAllWithPredicateAsync(Expression<Func<Conversation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Conversation> GetAsync(int pkId)
        {
            throw new NotImplementedException();
        }

        public Conversation GetWithPredicate(Expression<Func<Conversation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Conversation> GetWithPredicateAsync(Expression<Func<Conversation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Conversation TEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<ConversationResponse> DoConversation(string phrase)
        {
            //if (!await _connectivity.IsConnected())
            //throw new NoConnectionException();

            var data = await FetchDataFromServer(phrase);
            if (data != null)
                return data;

            return null;
        }

        public async Task<ConversationResponse> FetchDataFromServer(string phrase)
        {
            try
            {
                HttpResponseMessage data = null;
				data = await App.AppBaseHttpClient.GetAsync($"{Constants.WatsonSubURL}{phrase}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    var dataAsString = await data.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(dataAsString))
                    {
                        var obj = JsonConvert.DeserializeObject<ConversationResponse>(dataAsString);
                        return obj;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}