using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIC0378
{
    class UserList : ICollection<User>
    {
        private List<User> items = new List<User>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(User item)
        {
            this.items.Add(item);
        }

        public User Get(int index)
        {
            return this.items[index];
        }

        public void Set(int index, User item)
        {
            this.items[index] = item;
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(User item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<User> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public bool Remove(User item)
        {
            return this.items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public void Sort()
        {
            List<User> SortedList = items.OrderBy(o => o.Id).ToList();
            this.items.Clear();
            this.items = SortedList;
        }
    }
}
