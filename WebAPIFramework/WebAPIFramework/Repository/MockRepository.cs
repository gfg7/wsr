using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFramework.Interfaces;

namespace WebAPIFramework.Repository
{
    public class MockRepository : IRepository<string>
    {
        private static List<string> list = new List<string>();

        public Task<string> AddItem(string item)
        {
            if (list.Contains(item))
                throw new NotImplementedException();
            list.Add(item);
            return Task.Run(() => item);
        }


        public Task<string> DeleteByIndex(int i)
        {
            if (i >= list.Count)
                throw new NotImplementedException();
            var item = list.ElementAt(i);
            list.RemoveAt(i);
            return Task.Run(() => item);
        }

        public Task<string> DeleteByItem(string item)
        {
            if (!list.Contains(item))
                throw new NotImplementedException();
            var obj = item;
            list.Remove(item);
            return Task.Run(() => obj);
        }

        public Task<string> GetByIndex(int i)
        {
            if (i >= list.Count)
                throw new NotImplementedException();
            return Task.Run(() => list.ElementAt(i));
        }

        public Task<string> UpdateByIndex(string item, int i)
        {
            if (!list.Contains(item))
                throw new NotImplementedException();
            if (i >= list.Count)
                throw new NotImplementedException();
            DeleteByIndex(i);
            list.Add(item);
            return Task.Run(() => item);
        }

        public Task<List<string>> GetAll(string filter) => Task.Run(() => string.IsNullOrEmpty(filter) ? list : list?.Where(x => x.Contains(filter)).ToList());

        public Task<string> AddOnIndex(string item, int i)
        {
            if (i >= list.Count)
                throw new NotImplementedException();
            list.Add(item);
            return Task.Run(() => item);
        }
    }
}